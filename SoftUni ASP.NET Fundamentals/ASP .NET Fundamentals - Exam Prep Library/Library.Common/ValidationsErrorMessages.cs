﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    public static class ValidationsErrorMessages
    {
        // Book
        public const string BookTitleInccorectLength = "The title length must be between {2} and {1} characters long!";
        public const string BookAuthorInccorectLength = "The author name length must be between {2} and {1} characters long!";
        public const string BookDescriptionInccorectLength = "The description length must be between {2} and {1} characters long!";

        // Category
        public const string CategoryNameInccorectLength = "The category name must be between {2} and {1} charachers long!";
    }
}
