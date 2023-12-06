using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Medicines.Utilities.GlobalConstants;

namespace Medicines.Data.Models
{
    public class Medicine
    {
        public Medicine() 
        {
            PatientsMedicines = new HashSet<PatientMedicine>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MedicineNameLengthMax)]
        public string Name { get; set; } = null!;

        [Required]
        [Range((double)MedicinePriceRangeMin, (double)MedicinePriceRangeMax)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 4)]
        public Category Category { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [StringLength(MedicineProducerLengthMax)]
        public string Producer { get; set; } = null!;

        [Required]
        public int PharmacyId { get; set; }

        [ForeignKey(nameof(PharmacyId))]
        public virtual Pharmacy Pharmacy { get; set; } = null!;

        public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; }
    }
}
