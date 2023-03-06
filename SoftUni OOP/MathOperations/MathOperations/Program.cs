namespace Operations
{
    class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}