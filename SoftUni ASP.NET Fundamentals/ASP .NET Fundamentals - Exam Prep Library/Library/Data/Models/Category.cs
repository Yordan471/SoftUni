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

        /// <summary>
        /// Category Identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null;

        /// <summary>
        /// Collection of Books
        /// </summary>
        public ICollection<Book> Books { get; set; }
    }
}
