using ClassBoxData;

double lenght = double.Parse(Console.ReadLine());
double width =  double.Parse(Console.ReadLine());
double height = double.Parse(Console.ReadLine());

Box box = new();

try
{
   box = new(lenght, width, height);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
Console.WriteLine($"Volume - {box.Volume():f2}");