using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Utilities
{
    public class GlobalConstraints
    {
        // Boardgame
        public const int BoardgameNameLengthMin = 10;
        public const int BoardgameNameLengthMax = 20;
        public const double BoardgameRatingRangeMin = 1.0;
        public const double BoardgameRatingRangeMax = 10.0;
        public const int BoardGameYearPublishedMin = 2018;
        public const int BoardGameYearPublishedMax = 2023;

        // Sellar
        public const int SellarNameLengthMin = 5;
        public const int SellarNameLengthMax = 20;
        public const int SellarAddressLengthMin = 2;
        public const int SellarAddressLengthMax = 30;
        public const string SellarWebsiteRegexConstraint = @"^www\.[A-Za-z0-9\-]+\.com$";

        // Creator
        public const int CreatorNameLengthMin = 2;
        public const int CreatorNameLengthMax = 7;        
    }
}
