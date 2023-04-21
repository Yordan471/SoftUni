﻿using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
        private const int ValueZero = 0;

        private string name;
        private int portion;
        private decimal price;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }

                name = value;
            }
        }

        public int Portion
        {
            get => portion;
            private set
            {
                if (value <= ValueZero)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }

                portion = value;
            }
        }

        public decimal Price
        {
            get => price;
            private set
            {
                if (value <= ValueZero)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                price = value;
            }
        }
    }
}
