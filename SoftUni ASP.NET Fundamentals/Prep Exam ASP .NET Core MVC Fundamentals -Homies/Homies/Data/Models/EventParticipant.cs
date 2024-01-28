using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    public class EventParticipant
    {
        [Comment("Event helper identifier")]
        [Required]
        public string HelperId { get; set; } = string.Empty;

        [Comment("Helper entity")]
        [ForeignKey(nameof(HelperId))]
        public IdentityUser Helper { get; set; }

        [Comment("Event identifier")]
        [Required]
        public int EventId { get; set; }

        [Comment("Event entity")]
        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }
    }
}
