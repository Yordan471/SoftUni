namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ExportDto;
    using Footballers.Utilities;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches.
                Where(c => c.Footballers.Any())
                .ToArray()
                .Select(c => new ExportXmlCoachesDto()
                {
                    Name = c.Name,
                    FootballersCount = c.Footballers.Count,
                    Footballers = c.Footballers.Select(f => new ExportXmlFootballerDto()
                    {
                        Name = f.Name,
                        PositionType = f.PositionType
                    })
                    .OrderBy(f => f.Name)
                    .ToArray()
                })
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(f => f.Name)
                .ToArray();

            XmlHelper xmlHelper = new XmlHelper();
            string xmlRootName = "Coaches";

            return xmlHelper.Serializer(coaches, xmlRootName);
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(t => new
                {
                    t.Name,
                    Footballers = t.TeamsFootballers.Where(f => f.Footballer.ContractStartDate >= date).Select(f => new
                    {
                        FootballerName = f.Footballer.Name,
                        ContractStartDate = f.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = f.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = f.Footballer.BestSkillType.ToString(),
                        PositionType = f.Footballer.PositionType.ToString()
                    })
                    .OrderByDescending(f => f.ContractEndDate)
                    .ThenBy(f => f.FootballerName)
                    .ToArray()
                })
                .OrderByDescending(t => t.Footballers.Count())
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
