using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.ViewModel.Category;
using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.EntityValidationConstants.Ad;
using static SoftUniBazar.Common.EntityValidationErrorMessages;


namespace SoftUniBazar.ViewModel.Ad
{
    public class AddAdViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength,
            ErrorMessage = AdNameInccorectLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, 
            ErrorMessage = AdDescriptionInccorectLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();
    }
}
