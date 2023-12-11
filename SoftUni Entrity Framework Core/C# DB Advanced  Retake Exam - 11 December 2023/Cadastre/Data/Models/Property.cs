using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Data.Models
{
    public class Property
    {
        public Property() 
        {
            PropertiesCitizens = new HashSet<PropertyCitizen>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string PropertyIdentifier { get; set; } = null!;

        [Required]
        public int Area { get; set; }

        [StringLength(500)]
        public string? Details { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = null!;

        [Required]
        public DateTime DateOfAcquisition { get; set; }

        [Required]
        public int DistrictId { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public virtual District District { get; set; } = null!;

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
    }
}
