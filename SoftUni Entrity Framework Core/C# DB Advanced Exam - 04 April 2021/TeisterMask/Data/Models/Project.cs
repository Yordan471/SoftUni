using System.ComponentModel.DataAnnotations;
using static TeisterMask.Utilities.GlobalConstants;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project() 
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ProjectNameLengthMax)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime OpenDate { get; set; }

        public DateTime? DueDate { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
