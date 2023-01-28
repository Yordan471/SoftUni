using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
         static void Main()
         {
             Tire[] tires = new Tire[4]
             {
             new Tire(1, 2.5),
             new Tire(2, 3),
             new Tire(3, 3.5),
             new Tire(4, 4),
             };

             Engine engine = new(560, 6300);

             //Car car = new("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

            string command = string.Empty;

            List<Tire[]> tire = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] tireInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var currTire = new Tire[4];
                int count = 0;

                for (int i = 0; i < tireInfo.Length; i += 2)
                {
                    int year = int.Parse(tireInfo[i]);
                    double pressure = double.Parse(tireInfo[i + 1]);

                    var tiree = new Tire(year, pressure);

                    currTire[count] = tiree;                  
                    count++;
                }

                tire.Add(currTire);
            }

            string secondCommand = string.Empty;

            while ((secondCommand = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = secondCommand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);

                Engine currEngine = new(horsePower, cubicCapacity);

                engines.Add(currEngine);
            }

            string thirdCommand = string.Empty;

            while ((thirdCommand = Console.ReadLine()) != "Show special")
            {
                string[] carsInfo = thirdCommand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carsInfo[0];
                string model = carsInfo[1];
                int year = int.Parse(carsInfo[2]);
                double fuelQuantity = double.Parse(carsInfo[3]);
                double fuelConsumption = double.Parse(carsInfo[4]);
                int engineIndex = int.Parse(carsInfo[5]);
                int tiresIndex = int.Parse(carsInfo[6]);

                Car currCar = new(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tire[tiresIndex]);

                cars.Add(currCar);
            }

            var specialCar = cars
                .Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 &&
                x.Tires.Sum(p => p.Pressure) >= 9 && x.Tires.Sum(p => p.Pressure) <= 10)
                .ToList();

            foreach (Car special in specialCar)
            {
                special.Drive(20);
            }

            StringBuilder sb = new();

            foreach (Car special in specialCar)
            {
                sb.AppendLine($"Make: {special.Make}");
                sb.AppendLine($"Model: {special.Model}");
                sb.AppendLine($"Year: {special.Year}");
                sb.AppendLine($"HorsePowers: {special.Engine.HorsePower}");
                sb.AppendLine($"FuelQuantity: {special.FuelQuantity:f1}");
                Console.WriteLine(sb.ToString()); 
            }
         }      
    }
}
