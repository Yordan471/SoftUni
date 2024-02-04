using Homies.ViewModels.TypeViewModels;
using System.ComponentModel.DataAnnotations;
using static Homies.Common.EntityValidationConstants.Event;
using static Homies.Common.EntityValidationErrorMessages.EventErrorMessages;

namespace Homies.ViewModels.EventViewModels
{
    public class AddEventViewModel
    {
        /// <summary>
        /// Event Name
        /// </summary>
        [Required]
        [StringLength(maximumLength:NameMaxLength, MinimumLength = NameMinLength, 
            ErrorMessage = NameLengthInccorect)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Event description
        /// </summary>
        [Required]
        [StringLength(maximumLength:DescriptionMaxLength, MinimumLength = DescriptionMinLength, 
            ErrorMessage = DescriptionLengthInccorect)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Event start date
        /// </summary>
        [Required]
        public DateTime Start { get; set; }

        /// <summary>
        /// Event end date
        /// </summary>
        [Required]
        public DateTime End { get; set; }

        /// <summary>
        /// Event type identifier
        /// </summary>
        [Required]
        public int TypeId { get; set; }

        /// <summary>
        /// Types of events
        /// </summary>
        public IEnumerable<TypeViewModel> Types { get; set; } = new HashSet<TypeViewModel>();
    }
}
