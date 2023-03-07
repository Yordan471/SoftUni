using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private string favouriteFood;

        protected Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string FavouriteFood
        {
            get => favouriteFood;
            set => favouriteFood = value;
        }

        public virtual string ExmpainSelf()
        {
            return "";
        }
    }
}
