namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            string xmlRootName = "Creators";

            ImportXmlCreatorDto[] xmlCreatorDros = xmlHelper.Deserialize<ImportXmlCreatorDto[]>(xmlString, xmlRootName);

            ICollection<Creator> validCreators = new HashSet<Creator>();
            StringBuilder sb = new();

            foreach (var creatorDto in xmlCreatorDros)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator validCreator = new()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                };

                foreach (var boardgame in creatorDto.Boardgames)
                {
                    if (!IsValid(boardgame))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame validBoardgame = new()
                    {
                        Name = boardgame.Name,
                        Rating = boardgame.Rating,
                        YearPublished = boardgame.YearPublished,
                        CategoryType = (CategoryType)boardgame.CategoryType,
                        Mechanics = boardgame.Mechanics,
                    };

                    validCreator.Boardgames.Add(validBoardgame);
                }

                validCreators.Add(validCreator);
                sb.AppendLine(string.Format(
                    SuccessfullyImportedCreator, validCreator.FirstName, validCreator.LastName, validCreator.Boardgames.Count));
            }

            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            ImportJsonSellerDto[] jsonSellerDtos = JsonConvert.DeserializeObject<ImportJsonSellerDto[]>(jsonString);

            ICollection<Seller> validSellers = new HashSet<Seller>();
            StringBuilder sb = new();

            foreach (var sellerDto in jsonSellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller validSeller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website
                };

                foreach (var boardgame in sellerDto.Boardgames.Distinct())
                {
                    Boardgame existingBoardgame = context.Boardgames.Find(boardgame);

                    if (existingBoardgame == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validSeller.BoardgamesSellers.Add(new BoardgameSeller()
                    {
                        Boardgame = existingBoardgame
                    });
                }

                validSellers.Add(validSeller);
                sb.AppendLine(string.Format(
                    SuccessfullyImportedSeller, validSeller.Name, validSeller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(validSellers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
