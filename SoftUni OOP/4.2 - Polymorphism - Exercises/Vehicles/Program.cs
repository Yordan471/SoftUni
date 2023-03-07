using Vehicles;

List<Vehicle> vehicles = new List<Vehicle>();

for (int i = 0; i < 2; i++)
{
    string[] vehicleInfo = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string vehicleType = vehicleInfo[0];
    double fuelQuantity = double.Parse(vehicleInfo[1]);
    double fuelConsumption = double.Parse(vehicleInfo[2]);

    if (vehicleType == "Truck")
    {
        Vehicle vehicle = new Truck(fuelQuantity, fuelConsumption);
        vehicles.Add(vehicle);
    }
    else if (vehicleType == "Car")
    {
        Vehicle vehicle = new Car(fuelQuantity, fuelConsumption);
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
    

    if (commandType == "Drive")
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
    }
}

foreach (var vehicle in vehicles)
{
    Console.WriteLine(vehicle);
}