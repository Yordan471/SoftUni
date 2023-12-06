using System.ComponentModel.DataAnnotations;
using static Medicines.Utilities.GlobalConstants;

namespace Medicines.Data.Models
{
    public class Pharmacy
    {
        public Pharmacy() 
        {
            Medicines = new HashSet<Medicine>();
        }   

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(PharmacyNameLengthMax)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(PharmacyPhoneNumberLength)]
        [RegularExpression(PharmacyPhoneNumberRegularExpressionValidation)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public bool IsNonStop { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
