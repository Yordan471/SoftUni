using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Homies.Common.EntityValidationConstants.Event;

namespace Homies.Data.Models
{
    public class Event
    {
        public Event() 
        {
            EventsParticipants = new HashSet<EventParticipant>();
        }

        [Comment("Event identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Event name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Comment("Event description")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Comment("Event organiser identifier")]
        [Required]
        public string OrganiserId { get; set; } = string.Empty;

        [Comment("Event organiser identifier")]
        [Required]
        [ForeignKey(nameof(OrganiserId))]
        public IdentityUser? Organiser { get; set; }

        [Comment("Event created on")]
        [Required]
        public DateTime CreatedOn { get; set; }

        [Comment("Event started on")]
        [Required]
        public DateTime Start { get; set; }

        [Comment("Event ended on")]
        [Required]
        public DateTime End { get; set; }

        [Comment("Event type identifier")]
        [Required]
        public int TypeId { get; set; }

        [Comment("Type entity")]
        [Required]
        [ForeignKey(nameof(TypeId))]
        public Type? Type { get; set; }

        [Comment("Composite entity of event and participant")]
        public ICollection<EventParticipant> EventsParticipants { get; set; }
    }
}
