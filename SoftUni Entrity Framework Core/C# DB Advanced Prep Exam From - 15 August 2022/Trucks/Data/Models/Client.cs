using System.ComponentModel.DataAnnotations;
using static Trucks.Utilities.GlobalConstants;

namespace Trucks.Data.Models
{
    public class Client
    {
        public Client() 
        {
            ClientsTrucks = new HashSet<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ClientNameLengthMax)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ClientNationalityLengthMax)]
        public string Nationality { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
