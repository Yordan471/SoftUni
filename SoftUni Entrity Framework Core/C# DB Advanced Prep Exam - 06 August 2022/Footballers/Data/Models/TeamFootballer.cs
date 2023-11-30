using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.Data.Models
{
    public class TeamFootballer
    {
        [Required]
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; } = null!;

        [Required]
        public int FootballerId { get; set; }

        [ForeignKey(nameof(FootballerId))]
        public virtual Footballer Footballer { get; set; } = null!;
    }
}
