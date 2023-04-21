using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private Topping topping;
        private List<Topping> toppingList;

        public Pizza()
        {
            toppingList = new List<Topping>();
        }
        public Pizza(string name, Dough dough, Topping topping)           
        {
            //toppingList = new();

            this.Name = name;
            this.dough = dough;
            this.topping = topping;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
                
        }

        public Dough Dough
        {
            get => dough;
            set => this.dough = value;
        }

        public IReadOnlyCollection<Topping> ToppingList
        {
            get => toppingList;          
        }

        public int CountToppings { get => toppingList.Count; }
        

        public string CalculateCalories 
        { 
            get => $"{(dough.CalculateDroughCalories() + toppingList.Sum(t => t.CalculateCaloriesToppin())):f2}"; 
        }
  
        public void AddTopping(Topping topping)
        {
            if (toppingList.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppingList.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {CalculateCalories} Calories.";
        }
    }
}
