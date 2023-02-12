using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingNet
{
    public class Net
    {
        private readonly ICollection<Fish> fish;
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.fish = new List<Fish>();
        }
        public string  Material { get; set; }

        public int Capacity { get; set; }

        public IReadOnlyCollection<Fish> Fish => (IReadOnlyCollection<Fish>)this.fish;

        public int Count
        {
            get
            {
                return Fish.Count;
            }
        }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType) ||
                fish.Weight <= 0 || fish.Length <= 0)
            {
                return "Invalid fish.";
            }
            if (Count == this.Capacity)
            {
                return "Fishing net is full.";
            }

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if (this.fish.Any(f => f.Weight == weight))
            {
                Fish removeFish = this.fish.FirstOrDefault(f => f.Weight == weight);
                this.fish.Remove(removeFish);
                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            if (this.fish.Any(f => f.FishType == fishType))
            {
                return this.fish.FirstOrDefault(f => f.FishType.Equals(fishType));
            }

            return null;
        }

        public Fish GetBiggestFish()
        {
            Fish longestFish = null;

            if (this.fish.Count > 0)
            {
                foreach (var f in this.fish.OrderByDescending(f => f.Length))
                {
                    longestFish = f;
                    break;
                }
            }

            return longestFish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {this.Material}:");

            if (this.fish.Count > 0)
            {
                foreach (var f in fish.OrderByDescending(f => f.Length))
                {
                    sb.AppendLine($"{f}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
