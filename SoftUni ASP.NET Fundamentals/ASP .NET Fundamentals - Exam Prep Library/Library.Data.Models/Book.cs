using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Common.EntityValidationConstants;
using static Library.Common.EntityValidationConstants.Book;


namespace Library.Data.Models
{
    public class Book
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
        [StringLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Author Name
        /// </summary>
        [Required]
        [StringLength(AuthorMaxLength)]
        public string Author { get; set; } = null!;

        /// <summary>
        /// Book Description
        /// </summary>
        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Image of the Book
        /// </summary>
        [Required]
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// Book Rating
        /// </summary>
        [Required]
        [Range((double)RatingMaxValue, (double)RatingMinValue)]
        public decimal Rating { get; set; }

        /// <summary>
        /// Book CategoryId
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// Book Category
        /// </summary>
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        /// <summary>
        /// Collection of users with books
        /// </summary>
        public ICollection<IdentityUserBook> UsersBooks { get; set; }
    }
}
