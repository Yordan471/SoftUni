using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Abstract_Classes;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string[] foodInfo)
        {
            string food = foodInfo[0];
            int foodQuantity = int.Parse(foodInfo[1]);

            switch (food)
            {
                case "Vegetable":
                    return new Vegetable(foodQuantity);
                case "Meat":
                    return new Meat(foodQuantity);
                case "Seeds":
                    return new Seeds(foodQuantity);
                case "Fruit":
                    return new Fruit(foodQuantity);
                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
