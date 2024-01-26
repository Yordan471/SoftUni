using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniBazar.Common
{
    public static class EntityValidationErrorMessages
    {
        // Ad
        public const string AdNameInccorectLength = "Name length must be between {2} and {1} characters!";
        public const string AdDescriptionInccorectLength = "Description length must be between {2} and {1} characters!";

        // Category
        public const string CategoryDoesNotExist = "Category does not exist!";
    }
}
