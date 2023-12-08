﻿namespace Theatre.DataProcessor
{
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
            throw new NotImplementedException();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            throw new NotImplementedException();
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
