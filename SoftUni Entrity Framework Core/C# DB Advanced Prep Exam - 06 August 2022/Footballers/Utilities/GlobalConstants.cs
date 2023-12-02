using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.Utilities
{
    public class GlobalConstants
    {
        // Footballer
        public const int FootballerNameLengthMin = 2;
        public const int FootballerNameLengthMax = 40;

        // Team
        public const int TeamNameLengthMin = 3;
        public const int TeamNameLengthMax = 40;
        public const string TeamNameRegularExpressionValidation = @"^[a-zA-Z0-9 .-]+$";
        public const int TeamNationalityLengthMin = 2;
        public const int TeamNationalityLengthMax = 40;

        // Coach
        public const int CoachNameLenthMin = 2;
        public const int CoachNameLenthMax = 40;
    }
}
