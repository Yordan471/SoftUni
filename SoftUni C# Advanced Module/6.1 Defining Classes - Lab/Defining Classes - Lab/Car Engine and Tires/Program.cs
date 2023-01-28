
using Car_Engine_and_Tires;

namespace Car_Engine_and_Tires
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

            Car car = new("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

            Console.WriteLine($"Car {car.Make}, Model {car.Model}, Year {car.Year}");
        }
    }
}