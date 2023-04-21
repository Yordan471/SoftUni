using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int FreshwaterFishInitialSize = 3;
        private const int EatIncreasesInitialSizeByThree = 3;

        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
        }

        private void SetFishSize()
        {
            this.Size = FreshwaterFishInitialSize;
        }

        public override void Eat()
        {
            if (this.Size == 0)
            {
                this.SetFishSize();
            }
            
            this.Size += EatIncreasesInitialSizeByThree;   
        }
    }
}
