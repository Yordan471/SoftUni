using Invoices.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Utilities.GlobalConstants;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportXmlClientDto
    {        
        [Required]
        [MinLength(ClientFullNameLengthMin)]
        [MaxLength(ClientFullNameLengthMax)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(ClientVatNumberLengthMin)]
        [MaxLength(ClientVatNumberLengthMax)]
        [XmlElement("NumberVat")]
        public string NumberVat { get; set; } = null!;

        [XmlArray("Addresses")]
        public virtual ImportXmlAddressesDto[] Addresses { get; set; } = null!;
    }
}
