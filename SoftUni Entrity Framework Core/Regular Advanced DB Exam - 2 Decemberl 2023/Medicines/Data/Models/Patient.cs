using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static Medicines.Utilities.GlobalConstants;

namespace Medicines.Data.Models
{
    public class Patient
    {
        public Patient() 
        {
            PatientsMedicines = new HashSet<PatientMedicine>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(PatientFullNameLengthMax)]
        public string FullName { get; set; } = null!;

        [Required]
        [Range(0, 2)]
        public AgeGroup AgeGroup { get; set; }

        [Required]
        [Range(0, 1)]
        public Gender Gender { get; set; }

        public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; }
    }
}
