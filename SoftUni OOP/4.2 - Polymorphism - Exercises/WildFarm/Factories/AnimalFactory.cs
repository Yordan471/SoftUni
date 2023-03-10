using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Classes;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            switch(type)
            {
                case "Hen":
                    double wingSize = double.Parse(animalInfo[3]);
                    return new Hen(name, weight, wingSize);
                case "Owl":
                    wingSize = double.Parse(animalInfo[3]);
                    return new Owl(name, weight, wingSize);
                case "Mouse":
                    string livingRegion = animalInfo[3];
                    return new Mouse(name, weight, livingRegion);
                case "Dog":
                    livingRegion = animalInfo[3];
                    return new Dog(name, weight, livingRegion);
                case "Cat":
                    livingRegion = animalInfo[3];
                    string brood = animalInfo[4];
                    return new Cat(name, weight, livingRegion, brood);
                case "Tiger":
                    livingRegion = animalInfo[3];
                    brood = animalInfo[4];
                    return new Tiger(name, weight, livingRegion, brood);
                default:
                    throw new ArgumentException("Invalid animal type!");                  
            }
        }
    }
}
