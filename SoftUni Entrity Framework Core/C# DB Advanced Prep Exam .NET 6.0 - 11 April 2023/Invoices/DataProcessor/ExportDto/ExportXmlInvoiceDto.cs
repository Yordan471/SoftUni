using Invoices.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Invoice")]
    public class ExportXmlInvoiceDto
    {
        [XmlElement("InvoiceNumber")]
        public int Number { get; set; }

        [XmlElement("InvoiceAmount")]
        public decimal Amount { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlElement("Currency")]
        public string CurrencyType { get; set; }
    }
}
