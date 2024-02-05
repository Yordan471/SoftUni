using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Watchlist.Common.EntityValidationsConstants.Genre;

namespace Watchlist.Data.Models
{
    public class Genre
    {
        public Genre() 
        {
            Movies = new HashSet<Movie>();
        }

        [Comment("Genre identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Genre name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Comment("Collection of movies")]
        public ICollection<Movie> Movies { get; set; }
    }
}
