using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static Medicines.Utilities.GlobalConstants;

namespace Medicines.DataProcessor.ImportDtos
{
    public class ImportJsonPatientDto
    {
        [Required]
        [MinLength(PatientFullNameLengthMin)]
        [MaxLength(PatientFullNameLengthMax)]
        public string FullName { get; set; } = null!;

        [Required]
        [Range(0, 2)]
        public int AgeGroup { get; set; }

        [Required]
        [Range(0, 1)]
        public int Gender { get; set; }

        public int[] Medicines { get; set; }
    }
}
