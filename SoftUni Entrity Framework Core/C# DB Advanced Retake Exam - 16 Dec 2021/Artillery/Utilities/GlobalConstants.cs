using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artillery.Utilities
{
    public class GlobalConstants
    {
        // Country
        public const int CountryNameLengthMin = 5;
        public const int CountryNameLengthMax = 60;
        public const int CountryArmySizeMin = 50000;
        public const int CountryArmySizeMax = 10000000;

        // Manufacturer
        public const int ManufacturerNameLengthMin = 5;
        public const int ManufacturerNameLengthMax = 40;
        public const int ManufacturerFoundedLengthMin = 10;
        public const int ManufacturerFoundedLengthMax = 100;

        // Shell
        public const int ShellWeightMin = 100;
        public const int ShellWeightMax = 1350000;
        public const double ShellGunWeightMin = 2.00;
        public const double ShellGunWeightMax = 35.00;
        public const int ShellRangeMin = 1;
        public const int ShellRangeMax = 100000;
    }
}
