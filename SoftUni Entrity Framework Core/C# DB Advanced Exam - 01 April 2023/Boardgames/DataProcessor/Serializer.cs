namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .ToArray()
                .Select(c => new ExportXmlCreatorDto
                {
                    CreatorName = c.FirstName + " " + c.LastName,
                    BoardgamesCount = c.Boardgames.Count(),
                    Boardgames = c.Boardgames.Select(b => new ExportXmlBoardgameDto
                    {
                        Name = b.Name,
                        YearPublished = b.YearPublished,
                    })
                    .OrderBy(b => b.Name)
                    .ToArray()
                })
                .OrderByDescending(c => c.Boardgames.Count())
                .ThenBy(c => c.CreatorName)
                .ToArray();

            string xmlRootName = "Creators";

            XmlHelper xmlHelper = new XmlHelper();

            return xmlHelper.Serializer(creators, xmlRootName);
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year &&
                bs.Boardgame.Rating <= rating))
                .ToArray()
                .Select(s => new 
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
                                 .Where(bs => bs.Boardgame.YearPublished >= year &&
                                 bs.Boardgame.Rating <= rating)
                                 .Select(bs => new 
                                 {
                                     bs.Boardgame.Name,
                                     bs.Boardgame.Rating,
                                     bs.Boardgame.Mechanics,
                                     Category = bs.Boardgame.CategoryType.ToString()               
                                 })
                                 .OrderByDescending(bs => bs.Rating)
                                 .ThenBy(bs => bs.Name)
                                 .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Count())
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}