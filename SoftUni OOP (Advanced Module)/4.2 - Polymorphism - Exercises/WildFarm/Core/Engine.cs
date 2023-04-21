using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Classes;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IAnimalFactory animalFactory = new AnimalFactory();
        private readonly IFoodFactory foodsFactory = new FoodFactory();

        private ICollection<IAnimal> animals;

        public Engine(IAnimalFactory animalFactorym, IFoodFactory foodsFactory)
        {
            this.animalFactory = animalFactory;
            this.foodsFactory = foodsFactory;
            animals = new List<IAnimal>();             
        }

        public void Run()
        {
            string command = string.Empty; 

            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] foodInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IFood food = null;
                IAnimal animal = null;

                try
                {                   
                    animal = AnimalCreate(animalInfo);
                                                           
                    food = FoodCreate(foodInfo);

                    Console.WriteLine(animal.ProduceSound());

                    animal.EatFood(food);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private IFood FoodCreate(string[] foodInfo)
        {
            IFood food = foodsFactory.CreateFood(foodInfo);
            return food;         
        }

        private IAnimal AnimalCreate(string[] animalInfo)
        {
            IAnimal animal = animalFactory.CreateAnimal(animalInfo);
            return animal;

           // string animalType = animalInfo[0];
           // string animalName = animalInfo[1];
           //
           // switch (animalType)
           // {
           //     case "Cat":
           //         return new Cat(animalName, double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
           //     case "Tiger":
           //         return new Tiger(animalName, double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
           //     case "Owl":
           //         return new Owl(animalName, double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
           //     case "Hen":
           //         return new Hen(animalName, double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
           //     case "Mouse":
           //         return new Mouse(animalName, double.Parse(animalInfo[2]), animalInfo[3]);
           //     case "Dog":
           //         return new Mouse(animalName, double.Parse(animalInfo[2]), animalInfo[3]);
           //     default:
           //         throw new ArgumentException("Invalid animal type");
           // }
        }
    }
}
