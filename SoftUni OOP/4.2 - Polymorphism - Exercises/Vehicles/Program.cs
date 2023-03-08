using Vehicles;
using Vehicles.Models;

List<Vehicle> vehicles = new List<Vehicle>();

for (int i = 0; i < 3; i++)
{
    string[] vehicleInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string vehicleType = vehicleInfo[0];
    double fuelQuantity = double.Parse(vehicleInfo[1]);
    double fuelConsumption = double.Parse(vehicleInfo[2]);
    int capacity = int.Parse(vehicleInfo[3]);

    if (vehicleType == "Truck")
    {
        Vehicle vehicle = new Truck(fuelQuantity, fuelConsumption, capacity);
        vehicles.Add(vehicle);
    }
    else if (vehicleType == "Car")
    {
        Vehicle vehicle = new Car(fuelQuantity, fuelConsumption, capacity);
        vehicles.Add(vehicle);
    }
    else if (vehicleType == "Bus")
    {
        Vehicle vehicle = new Bus(fuelQuantity, fuelConsumption, capacity);
        vehicles.Add(vehicle);
    }
}


int numberOfCommands = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfCommands; i++)
{
    string[] commandInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string commandType = commandInfo[0];
    string vehicleType = commandInfo[1];
    
    try
    {
        if(commandType == "Drive" || commandType == "DriveEmpty")
        {   
            double distance = double.Parse(commandInfo[2]);

            if (vehicleType == "Car")
            {
                Vehicle driveVehicle = vehicles.FirstOrDefault(c => c.GetType().Name == "Car");
                Console.WriteLine(driveVehicle.Drive(distance));
            }
            else if (vehicleType == "Truck")
            {
                Vehicle driveVehicle = vehicles.FirstOrDefault(c => c.GetType().Name == "Truck");
                Console.WriteLine(driveVehicle.Drive(distance));
            }
            if (vehicleType == "Bus")
            {
                Vehicle driveVehicle = vehicles.FirstOrDefault(c => c.GetType().Name == "Bus");
                
                if (commandType == "DriveEmpty")
                {
                    Console.WriteLine(driveVehicle.Drive(distance, false));
                }
                else
                {
                    Bus busVehicle = (Bus)driveVehicle;
                    Console.WriteLine(busVehicle.Drive(distance));
                }
            }
        }
        else if (commandType == "Refuel")
        {
            double amount = double.Parse(commandInfo[2]);

            if (vehicleType == "Car")
            {
                Vehicle driveVehicle = vehicles.FirstOrDefault(c => c.GetType().Name == "Car");
                driveVehicle.Refuel(amount);
            }
            else if (vehicleType == "Truck")
            {
                Vehicle driveVehicle = vehicles.FirstOrDefault(c => c.GetType().Name == "Truck");
                driveVehicle.Refuel(amount);
            }
            else if (vehicleType == "Bus")
            {
                Vehicle driveVehicle = vehicles.FirstOrDefault(c => c.GetType().Name == "Bus");
                driveVehicle.Refuel(amount);
            }
        }
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

foreach (var vehicle in vehicles)
{
    Console.WriteLine(vehicle);
}