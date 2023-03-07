namespace Operations
{
    class StartUp
    {
        public static void Main()
        {
            MathOperations operation = new();

            Console.WriteLine(operation.Add(1, 2));

            Console.WriteLine(operation.Add(2.2, 2.3, 2.4));

            Console.WriteLine(operation.Add(2.5M, 2.4M, 2.989492M));

            //IEngine engine = new Engine();
            //
            //engine.Run();
        }
    }
}