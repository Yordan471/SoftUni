using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SoftUniBazar.Common.EntityValidationConstants.Ad;

namespace SoftUniBazar.Data.Models
{
    public class Ad
    {
        [Comment("Ad identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Ad name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("Ad description")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("Ad price")]
        [Required]
        public decimal Price { get; set; }

        [Comment("Owner identifier")]
        [Required]
        public string OwnerId { get; set; } = null!;

        [Comment("Ad owner")]
        [Required]
        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;

        [Comment("Ad image")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Ad date creation")]
        [Required]
        public DateTime CreatedOn { get; set; }

        [Comment("Category identifier")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("Ad category")]
        [Required]
        public Category Category { get; set; }
    }
}
