using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private int comfort;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fishes;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            
            Decorations = new List<IDecoration>();
            Fish = new List<IFish>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        public int Capacity { get => capacity; private set => capacity = value; }

        public int Comfort => CalculateCpmfort();

        public ICollection<IDecoration> Decorations { get; private set; }

        public ICollection<IFish> Fish { get; private set; }

        private int CalculateCpmfort()
        {           
            return Decorations.Sum(d => d.Comfort);          
        }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count >= this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.Fish.Add(fish);
        }

        public void Feed()
        {           
            foreach (var fish in Fish)
            {
                fish.Eat();
            }              
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();           

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.Append($"Fish: ");

            if (Fish.Count == 0)
            {
                sb.AppendLine($"none");
            }
            else
            {
                sb.AppendLine($"{string.Join(", ", Fish)}");
            }

            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }
    }
}
