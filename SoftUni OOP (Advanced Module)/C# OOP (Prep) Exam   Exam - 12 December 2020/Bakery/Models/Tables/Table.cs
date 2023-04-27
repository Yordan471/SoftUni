using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private const int ValueLessThenZero = 0;

        private int capacity;
        private int numberOfPeople;
        private ICollection<IDrink> DrinkOrders;
        private ICollection<IBakedFood> FoodOrders;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < ValueLessThenZero)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= ValueLessThenZero)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                numberOfPeople = value;
            }

        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => NumberOfPeople * Price;

        public void Clear()
        {
            DrinkOrders.Clear();
            FoodOrders.Clear();
            NumberOfPeople = 0;
            this.IsReserved = false;
        }

        public decimal GetBill()
        {
            throw new NotImplementedException();
        }

        public string GetFreeTableInfo()
        {
            throw new NotImplementedException();
        }

        public void OrderDrink(IDrink drink)
        {
            throw new NotImplementedException();
        }

        public void OrderFood(IBakedFood food)
        {
            throw new NotImplementedException();
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
