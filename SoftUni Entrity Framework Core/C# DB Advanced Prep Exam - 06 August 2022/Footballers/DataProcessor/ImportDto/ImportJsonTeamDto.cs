using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Footballers.Utilities.GlobalConstants;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportJsonTeamDto
    {
        [Required]
        [MaxLength(TeamNameLengthMax)]
        [MinLength(TeamNameLengthMin)]
        [RegularExpression(TeamNameRegularExpressionValidation)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(TeamNationalityLengthMax)]
        [MinLength(TeamNationalityLengthMin)]
        public string Nationality { get; set; } = null!;

        [Required]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] Footballers { get; set; } = null!;
    }
}
