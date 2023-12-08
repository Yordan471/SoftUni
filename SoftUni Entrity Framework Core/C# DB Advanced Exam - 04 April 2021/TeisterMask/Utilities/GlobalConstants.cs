using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeisterMask.Utilities
{
    public class GlobalConstants
    {
        // Employee
        public const int EmployeeUsernameLengthMin = 3;
        public const int EmployeeUsernameLengthMax = 40;
        public const string EmployeeUsernameRegularExpressionValidation = @"^[a-zA-Z0-9]+$";
        public const string EmployeeEmailRegularExpressionValidation = @"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        public const string EmployeePhoneRegularExpressionValidation = @"^[0-9]{3}-[0-9]{3}-[0-9]{4}$";

        // Project
        public const int ProjectNameLengthmin = 2;
        public const int ProjectNameLengthmax = 40;

        // Task
        public const int TaskNameLengthMin = 2;
        public const int TaskNameLengthMax = 40;
    }
}
