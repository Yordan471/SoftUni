using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Web.ViewModels.Board;
using static TaskBoardApp.Common.EntityValidationConstants.TaskValidationConstants;
using static TaskBoardApp.Common.EntityValidationErrorMessages;

namespace TaskBoardApp.Web.ViewModels.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(TaskTitleMaxLength, MinimumLength = TaskTitleMinLength,
            ErrorMessage = TitleIncorrectLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskDescriptionMaxLength, MinimumLength = TaskDescriptionMinLength, 
            ErrorMessage = DescriptionIncorrectLength)]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<BoardSelectModel>? Boards { get; set; }
    }
}
