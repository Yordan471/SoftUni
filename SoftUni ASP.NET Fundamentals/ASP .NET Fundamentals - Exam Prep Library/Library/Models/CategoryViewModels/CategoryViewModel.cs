using static Library.Common.ValidationsErrorMessages;
using static Library.Common.EntityValidationConstants.Category;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.CategoryViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength,
            ErrorMessage = CategoryNameInccorectLength)]
        public string Name { get; set; } = null!;
    }
}
