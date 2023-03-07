namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            Shape circle = new Circle(5);
            Shape rectanle = new Rectangle(2, 4);

            Console.WriteLine(circle.Draw());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());

            Console.WriteLine(rectanle.Draw());
            Console.WriteLine(rectanle.CalculateArea());
            Console.WriteLine(rectanle.CalculatePerimeter());
        }
    }
}