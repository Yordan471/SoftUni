namespace GenericScale
{
    public class StartUp
    {
        public static void Main()
        {
            EqualityScale<int> bol = new EqualityScale<int>(5, 5);
            Console.WriteLine(bol);
        }
    }
}