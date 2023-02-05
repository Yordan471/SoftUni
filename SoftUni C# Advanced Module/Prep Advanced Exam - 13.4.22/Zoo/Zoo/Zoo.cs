using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private string name;
        private int capacity;
        private List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            animals = new List<Animal>();
        }

        public string  Name { get; private set; }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<Animal> Animals => this.animals;

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (Animals.Count == this.Capacity)
            {
                return "The zoo is full.";
            }
            else
            {
                animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
        }

        public int RemoveAnimals(string species)
        {
            int countRemovedAnimals = 0;

            if (Animals.Any(a => a.Species == species))
            {
                while (Animals.FirstOrDefault(a => a.Species == species) != null)
                {
                    Animal removeAnimal = Animals.FirstOrDefault(a => a.Species == species);
                    animals.Remove(removeAnimal);
                    countRemovedAnimals++;
                }
            }

            return countRemovedAnimals;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalsWithSpecificDiet = new List<Animal>();

            foreach (Animal animal in Animals)
            {
                if (animal.Diet == diet)
                {
                    animalsWithSpecificDiet.Add(animal);
                }
            }

            return animalsWithSpecificDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.FirstOrDefault(a => a.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;

            foreach (Animal animal in Animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    count++;
                }
            }

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
