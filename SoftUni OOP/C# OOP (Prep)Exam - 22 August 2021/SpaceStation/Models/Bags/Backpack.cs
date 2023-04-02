using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private readonly ICollection<string> bags;

        public Backpack()
        {
            bags = new List<string>();
        }

        public ICollection<string> Items => bags;
    }
}
