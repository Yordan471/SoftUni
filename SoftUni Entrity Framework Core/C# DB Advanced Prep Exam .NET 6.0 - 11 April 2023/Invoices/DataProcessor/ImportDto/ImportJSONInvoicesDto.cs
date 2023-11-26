using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Utilities.GlobalConstants;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportJSONInvoicesDto
    {
        [Required]
        [Range(InvoicesNumberRangeMin, InvoicesNumberRangeMax)]
        public int Number { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [Range(0, 2)]
        public CurrencyType CurrencyType { get; set; }

        [Required]
        public int ClientId { get; set; }
    }
}
