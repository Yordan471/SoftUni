using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Watchlist.Common.EntityValidationsConstants.Movie;

namespace Watchlist.Data.Models
{
    public class Movie
    {
        public Movie() 
        {
            UsersMovies = new HashSet<UserMovie>();
        }

        [Comment("Movie identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Movie title name")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Comment("Movie director name")]
        [Required]
        [MaxLength(DirectorMaxLength)]
        public string Director { get; set; } = string.Empty;

        [Comment("Movie imageUrl path")]
        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Comment("Movie rating")]
        [Required]
        public decimal Rating { get; set; }

        [Comment("Movie genre identifier")]
        [Required]
        public int GenreId { get; set; }

        [Comment("Genre entity")]
        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        [Comment("Collection for users and movies")]
        public UserMovie UsersMovies { get; set; }
    }
}
