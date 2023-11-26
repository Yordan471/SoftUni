using Invoices.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class ExportXmlClientDto
    {
        [XmlElement("ClientName")]
        public string Name { get; set; } = null!;

        [XmlElement("VatNumber")]
        public string NumberVat { get; set; } = null!;

        [XmlAttribute("InvoicesCount")]
        public int InvoicesCount { get; set; }

        [XmlArray("Invoices")]
        public ExportXmlInvoiceDto[] Invoices { get; set; } = null!;
    }
}
