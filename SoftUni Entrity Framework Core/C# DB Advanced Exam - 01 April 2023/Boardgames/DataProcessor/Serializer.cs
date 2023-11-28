namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            throw new NotImplementedException();
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
                                     bs.Boardgame.CategoryType                  
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