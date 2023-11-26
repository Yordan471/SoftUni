using System.ComponentModel.DataAnnotations;
using static Boardgames.Utilities.GlobalConstraints;

namespace Boardgames.Data.Models
{
    public class Creator
    {
        public Creator() 
        {
            Boardgames = new HashSet<Boardgame>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CreatorNameLengthMax)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(CreatorNameLengthMax)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Boardgame> Boardgames { get; set; }
    }
}
