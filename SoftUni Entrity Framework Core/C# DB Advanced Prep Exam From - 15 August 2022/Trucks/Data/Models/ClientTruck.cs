using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Data.Models
{
    public class ClientTruck
    {
        [Required]
        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; } = null!;

        [Required]
        public int TruckId { get; set; }

        [ForeignKey(nameof(TruckId))]
        public virtual Truck Truck { get; set; } = null!;
    }
}
