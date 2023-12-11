using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Data.Models
{
    public class PropertyCitizen
    {
        [Required]
        public int PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public virtual Property Property { get; set; } = null!;

        [Required]
        public int CitizenId { get; set; }

        [ForeignKey(nameof(CitizenId))]
        public virtual Citizen Citizen { get; set; } = null!;
    }
}
