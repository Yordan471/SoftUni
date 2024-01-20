using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    public class EntityValidationConstants
    {
        public class Book
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;
            public const int AuthorMaxLength = 50;
            public const int AuthorMinLength = 5;
            public const int DescriptionMaxLength = 5000;
            public const int DescriptionMinLength = 5;
            public const decimal RatingMaxValue = 10.00M;
            public const decimal RatingMinValue = 0.00M;     
        }
    }
}
