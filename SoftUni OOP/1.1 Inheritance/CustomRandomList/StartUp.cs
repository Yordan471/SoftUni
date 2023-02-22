namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            RandomList randomList = new()
            {
                "pesho",
                "spas"
            };

            Console.WriteLine(randomList.RemoveString()); 
        }
    }
}