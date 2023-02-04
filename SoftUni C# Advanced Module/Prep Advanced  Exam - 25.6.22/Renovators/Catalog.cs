using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int neededRenovatos;
        private string project;
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new List<Renovator>();
        }

        public string Name { get; private set; }

        public int NeededRenovators { get; private set; }

        public string Project { get; set; }

        public IReadOnlyCollection<Renovator> Renovators => this.renovators;

        public int Count => this.Renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (Count == NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                this.renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            if (Renovators.Any(r => r.Name == name))
            {
                Renovator removeRenovator = Renovators.FirstOrDefault(r => r.Name == name);
                this.renovators.Remove(removeRenovator);
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int countRemovedRenovators = 0;

            while (Renovators.FirstOrDefault(r => r.Type == type) != null)
            {
                Renovator removeRenovator = Renovators.First(r => r.Type == type);
                this.renovators.Remove(removeRenovator);
                countRemovedRenovators++;
            }

            return countRemovedRenovators;
        }

        public Renovator HireRenovator(string name)
        {
            if (Renovators.Any(r => r.Name.Equals(name)))
            {
                Renovator hiredRenovator = this.Renovators.First(r => r.Name.Equals(name));
                hiredRenovator.Hired = true;
                return hiredRenovator;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return renovators.FindAll(r => r.Days >= days);
        }
    

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach(var renovator in this.Renovators.Where(r => r.Hired != true))
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
