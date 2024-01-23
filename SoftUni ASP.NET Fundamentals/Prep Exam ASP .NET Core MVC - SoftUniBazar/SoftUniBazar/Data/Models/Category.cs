namespace SoftUniBazar.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static SoftUniBazar.Common.EntityValidationConstants.Category;

    public class Category
    {
        public Category() 
        {
            Ads = new HashSet<Ad>();
        }

        [Comment("Category identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Category name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("Ad Collection")]
        public ICollection<Ad> Ads { get; set; }
    }
}
