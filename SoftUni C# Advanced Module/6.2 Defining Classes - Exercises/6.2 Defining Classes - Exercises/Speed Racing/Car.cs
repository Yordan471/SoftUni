using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    {
        //private List<Car> cars;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = travelledDistance;
        }

        public Car()
        {
            this.Cars = new List<Car>();
        }
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public List<Car> Cars { get; set; }

        public void GetVehicles(Car vehicle)
        {
            Cars.Add(vehicle);
        }

        public void Drive(int distance)
        {
            double neededFuel = distance * this.FuelConsumptionPerKilometer;

            if (neededFuel <= this.FuelAmount)
            {
                FuelAmount -= neededFuel;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive") ;
            }
        }
    }
}
