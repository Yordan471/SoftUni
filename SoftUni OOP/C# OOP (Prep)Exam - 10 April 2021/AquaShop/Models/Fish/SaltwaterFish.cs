using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int SaltwaterFishInitialSize = 5;
        private const int EatIncreasesInitialSizeByTwo = 2;

        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
        }

        private void SetFishSize()
        {
            this.Size = SaltwaterFishInitialSize;
        }

        public override void Eat()
        {
            if (this.Size == 0)
            {
                this.SetFishSize();
            }

            this.Size += EatIncreasesInitialSizeByTwo;
        }
    }
}
