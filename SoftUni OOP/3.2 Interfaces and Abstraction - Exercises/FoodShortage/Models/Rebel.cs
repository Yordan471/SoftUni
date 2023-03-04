using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage
{
    public class Rebel : IPerson, IBuyer
    {
        private const int rebelFood = 5;

        private int food;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food
        {
            get => food;
            private set
            {
                food = value;
            }
        }

        public void BuyFood()
        {
            food += rebelFood;
        }
    }
}
