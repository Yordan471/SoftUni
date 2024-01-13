using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskBoardApp.Data.Models
{
    using static TaskBoardApp.Common.EntityValidationConstants.TaskValidationConstants;
    using static TaskBoardApp.Common.EntityValidationErrorMessages;
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TaskTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(TaskDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public DateTime CreateOn { get; set; }

        public int BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        public virtual Board? Board { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;

        public virtual IdentityUser Owner { get; set; } = null!;
    }
}
