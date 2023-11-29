using System.ComponentModel.DataAnnotations;
using static Trucks.Utilities.GlobalConstants;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        public Despatcher() 
        {
            Trucks = new HashSet<Truck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DespatcherNameLengthMax)]
        public string Name { get; set; } = null!;

        public string? Position { get; set; }

        public ICollection<Truck> Trucks { get; set; }
    }
}
