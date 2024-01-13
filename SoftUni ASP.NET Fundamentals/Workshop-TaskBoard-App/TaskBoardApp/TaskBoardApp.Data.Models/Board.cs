using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.EntityValidationConstants.BoardValidationConstants;
using static TaskBoardApp.Common.EntityValidationErrorMessages;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        public Board() 
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
