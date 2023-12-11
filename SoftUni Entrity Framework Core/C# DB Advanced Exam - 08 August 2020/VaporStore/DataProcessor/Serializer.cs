namespace VaporStore.DataProcessor
{ 
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.ExportDto;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .ToArray()
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games.Where(gg => gg.Purchases.Any()).Select(gg => new
                    {
                        Id = gg.Id,
                        Title = gg.Name,
                        Developer = gg.Developer.Name,
                        Tags = gg.GameTags.Select(gt => string.Join(", ", gt.Tag.Name)),
                        Players = gg.Purchases.Count
                    })
                    .OrderByDescending(gg => gg.Players)
                    .ThenBy(gg => gg.Id)
                    .ToArray(),
                    TotalPlayers = g.Games.Sum(ga => ga.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            return JsonConvert.SerializeObject(genres, Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string purchaseType)
        {
            var users = context.Users
                .Where(u => u.Cards.Any(c => c.Purchases.Any()))
                .ToArray()
                .Select(u => new ExportXmlUserDto
                {
                    username = u.Username,
                    Purchases = u.Cards.
                })
        }
    }
}