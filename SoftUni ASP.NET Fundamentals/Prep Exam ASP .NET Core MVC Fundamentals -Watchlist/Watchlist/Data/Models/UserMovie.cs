using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watchlist.Data.Models
{
    public class UserMovie
    {
        [Comment("User identifier")]
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Comment("User entity")]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Comment("Movie identifier")]
        [Required]
        public int MovieId { get; set; }

        [Comment("Movie entity")]
        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; } = null!;
    }
}
