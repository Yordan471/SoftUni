using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public class Tea : Drink
    {
        private const decimal TeaPrice = 2.5M;

        public Tea(string name, int portion, string brand) : base(name, portion, TeaPrice, brand)
        {
        }
    }
}
