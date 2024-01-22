
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Common.EntityValidationConstants.Book;


namespace Library.Data.Models
{
    public class Book
    {
        public Book() 
        {
            UsersBooks = new HashSet<IdentityUserBook>();
        }

        [Comment("Book Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Book Title")]
        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Comment("Author Name")]
        [Required]
        [StringLength(AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Comment("Book Description")]
        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("Image of the Book")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Book Rating")]
        [Required]
        [Range((double)RatingMaxValue, (double)RatingMinValue)]
        public decimal Rating { get; set; }

        [Comment("Book CategoryId")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("Book Category")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Comment("Collection of users with books")]
        public ICollection<IdentityUserBook> UsersBooks { get; set; }
    }
}
