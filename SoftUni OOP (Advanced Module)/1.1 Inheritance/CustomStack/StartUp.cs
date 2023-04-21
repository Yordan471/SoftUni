namespace CustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            StackOfStrings stack = new();

            string[] array = new string[4]
            {
                "pesho",
                "gosho",
                "sasho",
                "demit"
            };

            stack.AddRange(array);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
