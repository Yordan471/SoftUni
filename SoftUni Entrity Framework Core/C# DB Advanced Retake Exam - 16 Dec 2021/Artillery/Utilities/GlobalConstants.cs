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
        public const int CountryNameLengthMin = 4;
        public const int CountryNameLengthMax = 60;
        public const int CountryArmySizeMin = 50000;
        public const int CountryArmySizeMax = 10000000;

        // Manufacturer
        public const int ManufacturerNameLengthMin = 4;
        public const int ManufacturerNameLengthMax = 40;
        public const int ManufacturerFoundedLengthMin = 10;
        public const int ManufacturerFoundedLengthMax = 100;

        // Shell
        public const double ShellWeightMin = 2.00;
        public const double ShellWeightMax = 1600.00;
        public const int ShellCaliberLengthMin = 4;
        public const int ShellCaliberLengthMax = 30;

        // Gun
        public const int GunWeightMin = 100;
        public const int GunWeightMax = 1350000;
        public const double GunBarrelLengthMin = 2.00;
        public const double GunBarrelLengthMax = 35.00;
        public const int GunRangeMin = 1;
        public const int GunRangeMax = 100000;
    }
}
