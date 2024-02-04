using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homies.Common
{
    public static class EntityValidationErrorMessages
    {
        public static class EventErrorMessages
        {
            public const string NameLengthInccorect = 
                "Event name must be between {1} and {0} characters long!";
            public const string DescriptionLengthInccorect =
                "Event description must be between {1} and {0} characters long!";
        }
        
        public static class TypeErrorMessages
        {
            public const string NameLengthInccorect = "Type name must be between {1} and {0} characters long!";
        }
    }
}
