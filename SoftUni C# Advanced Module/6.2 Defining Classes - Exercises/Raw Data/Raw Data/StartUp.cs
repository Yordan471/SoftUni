
namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                double firstTirePressure = double.Parse(carInfo[5]);
                int firstTireAge = int.Parse(carInfo[6]);
                double secondTirePressure = double.Parse(carInfo[7]);
                int secondTireAge = int.Parse(carInfo[8]);
                double thirdTirePressure = double.Parse(carInfo[9]);
                int thirdTireAge = int.Parse(carInfo[10]);
                double fourthTirePressure = double.Parse(carInfo[11]);
                int fourthTireAge = int.Parse(carInfo[12]);

                Car car = new(model, engineSpeed, enginePower, cargoWeight,
                    cargoType, firstTirePressure, firstTireAge, secondTirePressure,
                    secondTireAge, thirdTirePressure, thirdTireAge, fourthTirePressure,
                    fourthTireAge);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<Car> fragileCars = new();
                fragileCars = cars.Where(c => c.Cargo.Type == "fragile").ToList();

                foreach (var car in fragileCars)
                {
                    bool isBelowOne = false;

                    for (int i = 0; i < 4; i++)
                    {
                        if (car.Tires[i].Pressure < 1)
                        {
                            isBelowOne = true;
                            break;
                        }
                    }

                    if (isBelowOne)
                    {
                        Console.WriteLine(car.Model);
                    }                  
                }
            }
            else if (command == "flammable")
            {
                List<Car> fragileCars = new();
                fragileCars = cars
                    .Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                    .ToList();

                foreach (var car in fragileCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}