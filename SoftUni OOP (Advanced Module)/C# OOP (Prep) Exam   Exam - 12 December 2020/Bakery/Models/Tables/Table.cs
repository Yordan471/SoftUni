using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        public int TableNumber { get; private set; }

        public int Capacity => throw new NotImplementedException();

        public int NumberOfPeople => throw new NotImplementedException();

        public decimal PricePerPerson => throw new NotImplementedException();

        public bool IsReserved => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
