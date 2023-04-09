using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Utilities.Attributes
{
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object value);
    }
}
