using System.ComponentModel.DataAnnotations;
using static Homies.Common.EntityValidationConstants.Type;
using static Homies.Common.EntityValidationErrorMessages.TypeErrorMessages;

namespace Homies.ViewModels.TypeViewModels
{
    public class TypeViewModel
    {
        /// <summary>
        /// Type identifier
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Type name
        /// </summary>
        [Required]
        [StringLength(maximumLength:NameMaxLength, MinimumLength = NameMinLength, 
            ErrorMessage = NameLengthInccorect)]
        public string Name { get; set; } = string.Empty;
    }
}
