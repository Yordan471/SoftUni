using Bakery.Models.Drinks.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Bakery.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private const int ValueZero = 0;

        private string name;
        private int portion;
        private decimal price;
        private string brand;

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

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBrand);
                }

                brand = value;
            }
        }
    }
}
