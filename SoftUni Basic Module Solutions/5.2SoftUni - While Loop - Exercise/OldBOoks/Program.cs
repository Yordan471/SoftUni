using System;

namespace OldBOoks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            string enterBook;
            bool foundBook = false;
            int count = 0;
        
            while ((enterBook = Console.ReadLine()) != "No More Books")
            {
                if (enterBook == book)
                {
                    foundBook = true;
                    break;
                }
                count++;
               // enterBook = Console.ReadLine();
            }
            if (foundBook)
            {
                Console.WriteLine($"You checked {count} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {count} books.");
            }
        }
    }
}
