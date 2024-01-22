using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityValidationConstants.Category;

namespace Library.Data.Models
{
    public class Category
    {
        public Category() 
        {
            Books = new HashSet<Book>();    
        }

        [Comment("Category Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Category Name")]
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null;

        [Comment("Collection of Books")]
        public ICollection<Book> Books { get; set; }
    }
}
