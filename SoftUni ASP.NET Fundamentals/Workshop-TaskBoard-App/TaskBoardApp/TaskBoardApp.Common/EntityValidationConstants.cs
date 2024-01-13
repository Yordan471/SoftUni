using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardApp.Common
{
    public static class EntityValidationConstants
    {
        public static class TaskValidationConstants
        {
            public const int TaskTitleMinLength = 5;
            public const int TaskTitleMaxLength = 70;
            public const int TaskDescriptionMinLength = 10;
            public const int TaskDescriptionMaxLength = 1000;
        }

        public static class BoardValidationConstants
        {
            public const int BoardNameMinLength = 3;
            public const int BoardNameMaxLength = 30;
        }
    }
}
