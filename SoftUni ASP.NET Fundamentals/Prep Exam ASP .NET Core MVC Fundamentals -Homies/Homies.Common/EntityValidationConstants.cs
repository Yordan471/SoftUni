using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homies.Common
{
    public static class EntityValidationConstants
    {
        public static class Event
        {
            public const int NameMaxLength = 20;
            public const int NameMinLength = 5;
            public const int DescriptionMaxLength = 150;
            public const int DescriptionMinLength = 15;
        }

        public static class Type
        {
            public const int NameMaxLength = 15;
            public const int NameMinLength = 5;
        }
    }
}
