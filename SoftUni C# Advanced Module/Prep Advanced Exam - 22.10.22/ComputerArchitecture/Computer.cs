using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer()
        {
            this.Model = string.Empty;
            this.Capacity = 0;
            this.Multiprocessor = new();
        }

        public Computer(string model, int capacity) : this()
        {
            Model = model;
            Capacity = capacity;
        }

        public string Model { get; set; }

        public int Capacity { get; set; }

        public List<CPU> Multiprocessor  { get; set; }

        public int Count
        {
            get
            {
                return this.Multiprocessor.Count;
            }
        }

        public void Add(CPU cpu)
        {
            if (Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }                
        }

        public bool Remove(string brand)
        {
            if (Multiprocessor.Any(c => c.Brand == brand))
            {
                CPU removeCPU = Multiprocessor.Find(c => c.Brand == brand);
                Multiprocessor.Remove(removeCPU);
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            CPU mostPowerfulCPU = new CPU();

            mostPowerfulCPU = Multiprocessor
                .OrderByDescending(c => c.Frequency)
                .FirstOrDefault();

            return mostPowerfulCPU;
        }

        public CPU GetCPU(string brand)
        {
            CPU getCPU = new();

            if (Multiprocessor.Any(c => c.Brand.Equals(brand)))
            {
               return getCPU = Multiprocessor
                    .Find(c => c.Brand.Equals(brand));
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new();

            sb.AppendLine($"CPUs in the Computer {this.Model}:");

            foreach (CPU cpu in Multiprocessor)
            {
                sb.AppendLine($"{cpu}");
               // sb.AppendLine($"{cpu.Brand} CPU:");
               // sb.AppendLine($"Cores: {cpu.Cores}");
               // sb.AppendLine($"Frequency: {cpu.Frequency}");
            }

            return sb.ToString().Trim();
        }
    }
}
