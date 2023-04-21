using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        private const int SatchelCapacity = 25;

        public Satchel() : base(SatchelCapacity)
        {
        }
    }
}
