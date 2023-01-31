
using System.ComponentModel;

namespace SoftUniParking
{ 
    public class Program
    {
        public static void Main()
        {
            int numberOfCommads = int.Parse(Console.ReadLine());

            List<CarDriver> carDrivers = new List<CarDriver>();

            for (int i = 0; i < numberOfCommads; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputInfo.Length == 3)
                {
                    string name = inputInfo[1];
                    string license = inputInfo[2];

                    if (!carDrivers.Any(c => c.Name == name))
                    {
                        CarDriver carDriver = new(name, license);
                        carDrivers.Add(carDriver);
                        Console.WriteLine($"{name} registered {license} successfully");
                        continue;
                    }

                    Console.WriteLine($"ERROR: already registered with plate number {license}");
                }
                else if (inputInfo.Length == 2)
                {
                    string name = inputInfo[1];

                    if (carDrivers.Any(c => c.Name == name))
                    {
                        carDrivers.Remove(carDrivers.First(n => n.Name == name));
                        Console.WriteLine($"{name} unregistered successfully");
                        continue;
                    }

                    Console.WriteLine($"ERROR: user {name} not found");
                }
            }

            foreach (var carDriver in carDrivers)
            {
                Console.WriteLine(carDriver);
            }
        }
    }

    public class CarDriver
    {
        public CarDriver()
        {
            this.Name = string.Empty;
            this.License = string.Empty;

        }

        public CarDriver(string name, string license) : this()
        {
            this.Name = name;
            this.License = license;
        }


        public string Name { get; set; }

        public string License { get; set; }

        public List<CarDriver> CarDrivers = new List<CarDriver>();

        public override string ToString()
        {
            return $"{this.Name} => {this.License}".ToString();
        }
    }
}


