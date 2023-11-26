using System.ComponentModel.DataAnnotations;
using static Boardgames.Utilities.GlobalConstraints;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        public Seller() 
        {
            BoardgamesSellers = new HashSet<BoardGameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(SellarNameLengthMax)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(SellarAddressLengthMax)]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        public string Website { get; set; } = null!;

        public virtual ICollection<BoardgameSeller> BoardgamesSellers  { get; set; }
    }
}
