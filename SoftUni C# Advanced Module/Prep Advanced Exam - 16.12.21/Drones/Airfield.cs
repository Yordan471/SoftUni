using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    public class Airfield
    {
        private readonly ICollection<Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.drones = new List<Drone>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public IReadOnlyCollection<Drone> Drones => (IReadOnlyCollection<Drone>)this.drones;

        public int Count
        {
            get
            {
                return drones.Count;
            }
        }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) ||
                drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (this.Count == this.Capacity)
            {
                return "Airfield is full.";
            }

            drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            if (Drones.Any(d => d.Name == name))
            {
                Drone removeDrone = drones.First(drones => drones.Name == name);
                drones.Remove(removeDrone);
                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int countRemovedDrones = 0;

            while (drones.Any(d => d.Brand == brand))
            {
                Drone removeDrone = drones.First(d => d.Brand == brand);
                drones.Remove(removeDrone);
                countRemovedDrones++;
            }

            return countRemovedDrones;
        }

        public Drone FlyDrone(string name)
        {
            if (drones.Any(d => d.Name == name))
            {
                Drone flyDrone = drones.First(d => d.Name == name);
                flyDrone.Available = false;
                return flyDrone;
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flyDrones = new List<Drone>();

            if (drones.Any(d => d.Range >= range))
            {
                flyDrones = drones.Where(d => d.Range >= range).ToList();
                flyDrones.Any(d => d.Available = false);

                return flyDrones;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in drones.Where(d => d.Available == true))
            {
                sb.AppendLine($"{drone}");
            }

            return sb.ToString().Trim();
        }
    }
}
