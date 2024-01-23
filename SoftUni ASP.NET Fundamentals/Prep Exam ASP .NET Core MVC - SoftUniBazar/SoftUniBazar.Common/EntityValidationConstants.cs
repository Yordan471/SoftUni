using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniBazar.Common
{
    public static class EntityValidationConstants
    {
        public static class Ad
        {
            public const int NameMaxLength = 25;
            public const int NameMinLength = 5;
            public const int DescriptionMaxLength = 250;
            public const int DescriptionMinLength = 15;
        }

        public static class Category
        {
            public const int NameMaxLength = 15;
            public const int NameMinLength = 3;
        }
    }
}
