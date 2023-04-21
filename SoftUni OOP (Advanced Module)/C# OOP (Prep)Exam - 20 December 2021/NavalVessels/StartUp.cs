namespace NavalVessels
{
    using Core;
    using Core.Contracts;
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}