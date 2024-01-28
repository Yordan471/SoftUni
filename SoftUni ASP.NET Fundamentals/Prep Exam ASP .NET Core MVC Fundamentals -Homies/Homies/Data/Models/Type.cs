using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Homies.Common.EntityValidationConstants.Type;

namespace Homies.Data.Models
{
    public class Type
    {
        public Type()
        {
            Events = new HashSet<Event>();
        }

        [Comment("Event type identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Event type Name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Comment("Collection of events")]
        public ICollection<Event> Events { get; set; }
    }
}
