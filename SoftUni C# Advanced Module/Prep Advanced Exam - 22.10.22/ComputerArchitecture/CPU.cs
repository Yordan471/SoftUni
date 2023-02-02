using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        public CPU()
        {
            this.Brand = string.Empty;
            this.Cores = 0;
            this.Frequency = 0;
        }

        public CPU(string brand, int cores, double frequency) : this()
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        public string Brand { get; set; }

        public int Cores { get; set; }

        public double Frequency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"{this.Brand} CPU:");
            sb.AppendLine($"Cores: {this.Cores}");
            sb.AppendLine($"Frequency: {this.Frequency:f1} GHz");

            return sb.ToString().Trim();
        }
    }
}
