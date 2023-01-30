using CarSalesman;
public class StartUp
{
    public static void Main()
    {
        int numberOfEngines = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < numberOfEngines; i++)
        {
            string[] engineInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = engineInfo[0];
            int power = int.Parse(engineInfo[1]);

            Engine engine = new();

            if (engineInfo.Length == 2)
            {
                engine = new(model, power);
            }
            else if (engineInfo.Length == 3 && char.IsDigit(engineInfo[2][0]))
            {
                int displacement = int.Parse(engineInfo[2]);

                engine = new(model, power, displacement);
            }
            else if ((engineInfo.Length == 3 && char.IsLetter(engineInfo[2][0])))
            {
                string efficiency = engineInfo[2];

                engine = new(model, power, efficiency);
            }
            else
            {
                int displacement = int.Parse(engineInfo[2]);
                string efficiency = engineInfo[3];

                engine = new(model, power, displacement, efficiency);
            }

            engines.Add(engine);
        }

        int numberOfCars = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = carInfo[0];
            string engineModel = carInfo[1];
            Engine engine = engines.Find(e => e.Model.Equals(engineModel));

            Car car = new();

            if (carInfo.Length == 2)
            {
                car = new(model, engine);
            }
            else if (carInfo.Length == 3 && char.IsDigit(carInfo[2][0]))
            {
                int weight = int.Parse(carInfo[2]);

                car = new(model, engine, weight);
            }
            else if (carInfo.Length == 3 && char.IsLetter(carInfo[2][0]))
            {
                string color = carInfo[2];

                car = new(model, engine, color);
            }
            else
            {
                int weight = int.Parse(carInfo[2]);
                string color = carInfo[3];

                car = new(model, engine, weight, color);
            }

            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}

