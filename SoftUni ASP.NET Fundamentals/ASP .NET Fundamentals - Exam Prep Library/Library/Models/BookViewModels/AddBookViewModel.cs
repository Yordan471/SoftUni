using Library.Models.CategoryViewModels;
using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityValidationConstants.Book;
using static Library.Common.ValidationsErrorMessages;

namespace Library.Models.BookViewModels
{
    public class AddBookViewModel
    {
        /// <summary>
        /// Book Identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Book Title
        /// </summary>
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
            ErrorMessage = BookTitleInccorectLength)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Author Name
        /// </summary>
        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength,
            ErrorMessage = BookAuthorInccorectLength)]
        public string Author { get; set; } = null!;

        /// <summary>
        /// Book Description
        /// </summary>
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = BookDescriptionInccorectLength)]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Image of the Book
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; } = null!;

        /// <summary>
        /// Book Rating
        /// </summary>
        [Required]
        //[Range((double)RatingMaxValue, (double)RatingMinValue)]
        public string Rating { get; set; } = null!;

        /// <summary>
        /// Book CategoryId
        /// </summary>
        [Required]
        // Must be above 0
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; } = 
            new List<CategoryViewModel>();
    }
}
