using Invoices.Data.Models.Enums;
using Invoices.Data.Models;
using System.ComponentModel.DataAnnotations;
using static Invoices.Utilities.GlobalConstants;
using Newtonsoft.Json;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportJSONProductDto
    {
        [Required]
        [MinLength(ProductNameLengthConstraintMin)]
        [MaxLength(ProductNameLengthConstraintMax)]
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range((double)ProductPriceRangeMin, (double)ProductPriceRangeMax)]
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 4)]
        [JsonProperty("CategoryType")]
        public CategoryType CategoryType { get; set; }

        [JsonProperty("Clients")]
        public int[] Clients { get; set; } = null!;
    }
}
