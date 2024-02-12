using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchlist.Common
{
    public static class EntityValidationsConstants
    {
        public static class User
        {
            public const int UserNameMaxLength = 20;
            public const int UserNameMinLength = 5;
            public const int EmailMaxLength = 60;
            public const int EmailMinLength = 10;
            public const int PasswordMaxLength = 20;
            public const int PasswordMinLength = 5;
        }

        public static class Movie
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;
            public const int DirectorMaxLength = 50;
            public const int DirectorMinLength = 5;
            public const decimal RatingMaxValue = 10.00M;
            public const decimal RatingMinValue = 0.00M;
        }

        public static class Genre
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 5;
        }
    }
}
