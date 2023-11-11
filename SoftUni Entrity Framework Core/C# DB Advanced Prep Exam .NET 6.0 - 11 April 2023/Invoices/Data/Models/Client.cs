using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(15)]
        public string NumberVat { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<ProductClient> ProductsClients { get; set; }
    }
}