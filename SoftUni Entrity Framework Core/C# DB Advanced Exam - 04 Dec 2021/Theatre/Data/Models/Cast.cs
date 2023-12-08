using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Theatre.Utilities.GlobalConstants;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CastFullNameLengthMax)]
        public string FullName { get; set; } = null!;

        [Required]
        public bool IsMainCharacter { get; set; }

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public virtual Player Player { get; set; }
    }
}
