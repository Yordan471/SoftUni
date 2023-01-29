namespace SpeedRacing
{
    public class StartUp      
    {
        public static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            Car cars = new Car();

            for (int car = 0; car < numberOfCars; car++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);
                double travelledDistance = 0.0;

                Car vehicle = new(model, fuelAmount, fuelConsumptionPerKilometer, travelledDistance);

                cars.GetVehicles(vehicle);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = commandInfo[1];
                int amountOfKilometers = int.Parse(commandInfo[2]);

                foreach (Car car in cars.Cars)
                {
                    if (car.Model == model)
                    {
                        car.Drive(amountOfKilometers);
                    }
                }
            }

            PrintCars(cars);
        }

        private static void PrintCars(Car cars)
        {
            foreach (Car car in cars.Cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}