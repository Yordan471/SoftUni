using System.Reflection;

namespace Stealer
{
    public class StartUp
    {
        public static void Main()
        {
            Type type = typeof(Hacker);

            Spy spy = new Spy();

            //string outputInfo = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            string outputInfoSecondMethod = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            Console.WriteLine(outputInfoSecondMethod);
        }
    }
}