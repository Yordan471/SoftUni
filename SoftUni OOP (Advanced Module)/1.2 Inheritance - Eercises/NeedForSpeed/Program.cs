using NeedForSpeed;

RaceMotorcycle motor = new(200, 1200);
SportCar sportCar = new(200, 1200);
Car car = new(200, 1200);

motor.Drive(100);
Console.WriteLine(motor.Fuel);

sportCar.Drive(100);
Console.WriteLine(sportCar.Fuel);

car.Drive(100);
Console.WriteLine(car.Fuel);