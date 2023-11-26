using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Utilities.GlobalConstants;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Invoice")]
    public class ImportJSONInvoicesDto
    {
        [Required]
        [Range(InvoicesNumberRangeMin, InvoicesNumberRangeMax)]
        [XmlElement("Number")]
        public int Number { get; set; }

        [Required]
        [XmlElement("IssueDate")]
        public DateTime IssueDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public DateTime DueDate { get; set; }

        [Required]
        [XmlElement("Amount")]
        public decimal Amount { get; set; }

        [Required]
        [XmlElement("CurrencyType")]
        public CurrencyType CurrencyType { get; set; }

        [Required]
        [XmlElement("ClientId")]
        public int ClientId { get; set; }
    }
}
