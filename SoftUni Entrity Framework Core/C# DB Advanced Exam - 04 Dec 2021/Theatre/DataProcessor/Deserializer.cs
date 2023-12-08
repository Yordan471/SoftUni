namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;
    using Theatre.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlHelper xmlHelper = new();
            string xmlRootName = "Plays";

            ImportXmlPlayDto[] playDtos = xmlHelper.Deserialize<ImportXmlPlayDto[]>(xmlString, xmlRootName);

            ICollection<Play> validPlays = new HashSet<Play>();
            StringBuilder sb = new();
            TimeSpan oneHour = new(01, 00, 00);
            string[] genreArray = new string[]
            {
                "Drama",
                "omedy",
                "Romance",
                "Musical"
            };

            foreach (var playDto in playDtos)
            {
                if (IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan validTimeSpan = TimeSpan.Parse(playDto.Duration, CultureInfo.InvariantCulture);

                if (TimeSpan.Compare(validTimeSpan, oneHour) < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!genreArray.Contains(playDto.Genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play validPlay = new()
                {
                    Title = playDto.Title,
                    Duration = validTimeSpan,
                    Rating = playDto.Rating,
                    Genre = Enum.Parse<Genre>(playDto.Genre)
                };

                validPlays.Add(validPlay);
                sb.AppendLine(string.Format(
                    SuccessfulImportPlay, validPlay.Title, validPlay.Genre.ToString(), validPlay.Rating));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            string xmlRootName = "Casts";

            ImportXmlCastDto[] castDtos = xmlHelper.Deserialize<ImportXmlCastDto[]>(xmlString, xmlRootName);

            ICollection<Cast> validCasts = new HashSet<Cast>();
            StringBuilder sb = new StringBuilder();

            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool validIsMainCharacter;
                bool isValidBoolean = bool.TryParse(castDto.IsMainCharacter, out validIsMainCharacter);

                if (!isValidBoolean)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast validCast = new()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = validIsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                validCasts.Add(validCast);

                string mainOrLesser = validCast.IsMainCharacter == true ? "main" : "lesser";
                sb.AppendLine(string.Format(SuccessfulImportActor, validCast.FullName, mainOrLesser));
            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            ImportJsonTheatreDto[] theatreDtos = 
                JsonConvert.DeserializeObject<ImportJsonTheatreDto[]>(jsonString);

            ICollection<Theatre> validTheatres = new HashSet<Theatre>();
            StringBuilder sb = new();

            foreach (var theaterDto in theatreDtos)
            {
                if (!IsValid(theaterDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre validTheater = new()
                {
                    Name = theaterDto.Name,
                    NumberOfHalls = theaterDto.NumberOfHalls,
                    Director = theaterDto.Director,
                };

                foreach (var ticketDto in theaterDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket validTicket = new()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId,
                    };

                    validTheater.Tickets.Add(validTicket);
                }

                validTheatres.Add(validTheater);
                sb.AppendLine(string.Format(
                    SuccessfulImportTheatre, validTheater.Name, validTheater.Tickets.Count));
            }

            context.Theatres.AddRange(validTheatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
