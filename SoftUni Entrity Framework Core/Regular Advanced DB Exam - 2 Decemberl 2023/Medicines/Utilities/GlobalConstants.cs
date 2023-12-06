using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Utilities
{
    public class GlobalConstants
    {
        // Pharmacy
        public const int PharmacyNameLengthMin = 2;
        public const int PharmacyNameLengthMax = 50;
        public const int PharmacyPhoneNumberLength = 14;
        public const string PharmacyPhoneNumberRegularExpressionValidation = @"\({1}[0-9]{3}\){1} [0-9]{3}-{1}[0-9]{4}";

        // Medicine
        public const int MedicineNameLengthMin = 3;
        public const int MedicineNameLengthMax = 150;
        public const decimal MedicinePriceRangeMin = 0.01M;
        public const decimal MedicinePriceRangeMax = 1000.00M;
        public const int MedicineProducerLengthMin = 3;
        public const int MedicineProducerLengthMax = 100;

        // Patient
        public const int PatientFullNameLengthMin = 5;
        public const int PatientFullNameLengthMax = 100;
    }
}
