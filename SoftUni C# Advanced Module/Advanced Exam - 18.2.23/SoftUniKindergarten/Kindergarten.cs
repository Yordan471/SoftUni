using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Child> Registry { get; set; }

        public int ChildrenCount
        {
            get
            {
                return Registry.Count;
            }
        }

        public bool AddChild(Child child)
        {
            if (ChildrenCount >= this.Capacity)
            {
                return false;
            }

            Registry.Add(child);
            return true;
        }

        public bool RemoveChild(string childFullName)
        {
            if (Registry.Any(c => c.FirstName + " " + c.LastName == childFullName))
            {
                Child removeChild = Registry.First(c => c.FirstName + " " + c.LastName == childFullName);
                Registry.Remove(removeChild);
                return true;
            }

            return false;
        }

        public Child GetChild(string childFullName)
        {
            if (Registry.Any(c => c.FirstName + " " + c.LastName == childFullName))
            {
                Child getChild = Registry.First(c => c.FirstName + " " + c.LastName == childFullName);
                return getChild;
            }

            return null;
        }

        public string RegistryReport()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Registered children in {this.Name}:");

            if (this.ChildrenCount > 0)
            {
                foreach (var child in Registry
                    .OrderByDescending(c => c.Age)
                    .ThenBy(c => c.LastName)
                    .ThenBy(c => c.FirstName))
                {
                    sb.AppendLine(child.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
