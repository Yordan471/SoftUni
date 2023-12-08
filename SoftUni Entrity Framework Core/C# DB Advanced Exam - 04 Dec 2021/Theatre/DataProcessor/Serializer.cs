namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;
    using Theatre.Utilities;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            int[] rowNumbersArr = new int[] { 1, 2, 3, 4, 5 };

            var theaters = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .ToArray()
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                    .Where(t => rowNumbersArr.Contains(t.RowNumber)).Select(t => t.Price)
                    .Sum(),
                    Tickets = t.Tickets
                    .Where(t => rowNumbersArr.Contains(t.RowNumber))
                    .Select(t => new
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber
                    })
                    .OrderByDescending(t => t.Price)
                    .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theaters, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            var plays = context.Plays
                .Where(p => p.Rating <= raiting)
                .ToArray()
                .Select(p => new ExportXmlPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                    .Where(c => c.IsMainCharacter == true)
                    .Select(c => new ExportXmlCastDto()
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{c.Play.Title}'."
                    })
                    .OrderByDescending(c => c.FullName)
                    .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            XmlHelper xmlHelper = new();
            string xmlRootName = "Plays";

            return xmlHelper.Serializer(plays, xmlRootName);
        }
    }
}
