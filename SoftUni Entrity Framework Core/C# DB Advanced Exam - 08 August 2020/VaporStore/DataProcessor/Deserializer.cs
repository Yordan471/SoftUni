namespace VaporStore.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Castle.Core.Internal;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImportDto;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            ImportJsonGameDto[] gameDtos = 
                JsonConvert.DeserializeObject<ImportJsonGameDto[]>(jsonString);

            ICollection<Game> validGames = new HashSet<Game>();
            StringBuilder sb = new StringBuilder();

            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(gameDto.Name) ||
                    string.IsNullOrEmpty(gameDto.Genre) ||
                    string.IsNullOrEmpty(gameDto.Developer) ||
                    string.IsNullOrEmpty(gameDto.ReleaseDate) ||
                    gameDto.Tags.Length <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime parseReleaseDate;
                bool isReleaseDateValid = DateTime.TryParseExact(
                    gameDto.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out parseReleaseDate);

                if (!isReleaseDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Developer developer = context.Developers.First(d => d.Name == gameDto.Developer);
                if (developer == null)
                {
                    developer = new Developer()
                    {
                        Name = gameDto.Developer,
                    };
                }

                Genre genre = context.Genres.FirstOrDefault(g => g.Name == gameDto.Genre);
                if (genre == null)
                {
                    genre = new Genre()
                    {
                        Name = gameDto.Genre
                    };
                }

                Game validGame = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = parseReleaseDate,
                    Developer = developer,
                    Genre = genre,
                };

                foreach (var tagName in gameDto.Tags)
                {
                    Tag tag = context.Tags.FirstOrDefault(t => t.Name == gameDto.Name);
                    if (tag == null)
                    {
                        tag = new Tag()
                        {
                            Name = gameDto.Name
                        };
                    }

                    validGame.GameTags.Add(new GameTag
                    {
                        Tag = tag
                    });
                }

                validGames.Add(validGame);
                sb.AppendLine(string.Format(
                    SuccessfullyImportedGame, validGame.Name, validGame.Genre, validGame.GameTags.Count));
            }

            context.Games.AddRange(validGames);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            ImportJsonUserDto[] userDtos = 
                JsonConvert.DeserializeObject<ImportJsonUserDto[]>(jsonString);

            ICollection<User> validUsers = new HashSet<User>();
            StringBuilder sb = new();
            string[] typeArray = new string[] { "Debit", "Credit" };

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto) || !userDto.Cards.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool anyCardInvalid = false;

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto) || !typeArray.Contains(cardDto.Type.ToString()))
                    {
                        anyCardInvalid = true;
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }                   
                }

                if (anyCardInvalid)
                {
                    User validUser = new User()
                    {
                        FullName = userDto.FullName,
                        Username = userDto.Username,
                        Email = userDto.Email,
                        Age = userDto.Age
                    };

                    foreach (var cardDto in userDto.Cards)
                    {
                        Card validCard = new Card()
                        {
                            Number = cardDto.Number,
                            Cvc = cardDto.Cvc,
                            Type = Enum.Parse<CardType>(cardDto.Type)
                        };

                        validUser.Cards.Add(validCard);
                    }

                    validUsers.Add(validUser);
                    sb.AppendLine(string.Format(
                        SuccessfullyImportedUser, validUser.Username, validUser.Cards.Count));
                }
                else
                {
                    continue;
                }
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}