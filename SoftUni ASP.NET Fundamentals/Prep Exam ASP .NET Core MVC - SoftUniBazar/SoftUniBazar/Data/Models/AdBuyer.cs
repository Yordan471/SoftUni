using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Data.Models
{
    public class AdBuyer
    {
        [Comment("Buyer identifier")]
        [Required]
        public string BuyerId { get; set; } = null!;

        [Comment("Buyer entity")]
        [ForeignKey(nameof(BuyerId))]
        public IdentityUser Buyer { get; set; }

        [Comment("Ad identifier")]
        [Required]
        public int AdId { get; set; }

        [Comment("Ad entity")]
        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; }
    }
}
