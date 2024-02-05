using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchlist.Common
{
    public static class EntityValidationsConstants
    {
        public static class Movie
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;
            public const int DirectorMaxLength = 50;
            public const int DirectorMinLength = 5;
            public const double RatingMaxValue = 10.00;
            public const double RatingMinValue = 0.00;
        }

        public static class Genre
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 5;
        }
    }
}
