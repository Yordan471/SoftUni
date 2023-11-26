using Boardgames.Data.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Boardgames.Utilities.GlobalConstraints;

namespace Boardgames.Data.Models
{
    public class BoardGame
    {
        public BoardGame() 
        {
            BoardgamesSellers = new HashSet<BoardGameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(BoardgameNameLengthMax)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(BoardgameRatingRangeMin, BoardgameRatingRangeMax)]
        public double Rating { get; set; }

        [Required]
        [Range(BoardGameYearPublishedMin, BoardGameYearPublishedMax)]
        public int YearPublished { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public string Mechanics { get; set; } = null!;

        [Required]
        public int CreatorId { get; set; }

        [Required]
        [ForeignKey("CreatorId")]
        public virtual Creator Creator { get; set; } = null!;

        public ICollection<BoardgameSeller> BoardgamesSellers  { get; set; }
    }
}
