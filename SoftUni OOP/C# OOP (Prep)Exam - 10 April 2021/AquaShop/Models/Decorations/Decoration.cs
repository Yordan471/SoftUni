using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        public int Comfort => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();
    }
}
