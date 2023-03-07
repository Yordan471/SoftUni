using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;



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
