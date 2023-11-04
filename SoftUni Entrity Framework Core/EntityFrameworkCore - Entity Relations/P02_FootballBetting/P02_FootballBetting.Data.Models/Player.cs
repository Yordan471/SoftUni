using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        //PlayerId, Name, SquadNumber, TeamId, PositionId, IsInjured
        [Key]
        public int PlayerId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public int TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]

        public virtual Team Team { get; set; }

        public int PositionId { get; set; }
        [ForeignKey(nameof(PositionId))]
        public virtual Position Position { get; set; }

        public bool IsInjured { get; set; }
    }
}
