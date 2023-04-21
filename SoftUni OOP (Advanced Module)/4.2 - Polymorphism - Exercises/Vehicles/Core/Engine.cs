using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Core.Interfaces;
using Vehicles.Models.Interfaces;
using Vehicles.VehicleFactories;
using Vehicles.VehicleFactories.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IVehicleFactory vehicleFactory;
        private readonly ICollection<IVehicle> vehicles;

        public Engine(IVehicleFactory vehicleFactory)
        {
            this.vehicleFactory = vehicleFactory;

            vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            for (int i = 0; i < 3; i++)
            {
                vehicles.Add(CreateVehicle());
            }

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                try
                {
                    ImplementCommands();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }  
                catch(Exception)
                {
                    throw;
                }              
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private void ImplementCommands()
        {
            string[] commandInfo = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string operation = commandInfo[0];
            string vehicleType = commandInfo[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (operation == "Drive")
            {
                double distance = double.Parse(commandInfo[2]);
                Console.WriteLine(vehicle.Drive(distance));
            }
            else if (operation == "DriveEmpty")
            {
                double distance = double.Parse(commandInfo[2]);
                Console.WriteLine(vehicle.Drive(distance, false));
            }
            else if (operation == "Refuel")
            {
                double amount = double.Parse(commandInfo[2]);
                vehicle.Refuel(amount);
            }
        }


        private IVehicle CreateVehicle()
        {
            string[] vehicleInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return vehicleFactory.Create(vehicleInfo[0], double.Parse(vehicleInfo[1]), double.Parse(vehicleInfo[2]), int.Parse(vehicleInfo[3]));
        }
    }
}


