using System;

namespace VacationBooksList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            int broistr = int.Parse(Console.ReadLine());

            Console.WriteLine(" ");
            int stranici = int.Parse(Console.ReadLine());

            Console.WriteLine(" ");
            int numberDays = int.Parse(Console.ReadLine());

            int time1 = broistr / stranici;
            int result = time1 / numberDays;

            Console.WriteLine(result);
        }
    }
}
