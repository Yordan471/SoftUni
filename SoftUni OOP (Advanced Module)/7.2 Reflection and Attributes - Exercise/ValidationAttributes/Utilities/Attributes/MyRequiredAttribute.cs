using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object value)
           => value != null;
    }
}
