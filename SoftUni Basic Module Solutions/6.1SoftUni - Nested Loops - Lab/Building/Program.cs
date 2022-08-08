using System;

namespace Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int fl = floors; fl >= 1; fl--)
            {
                for (int room = 0; room < rooms; room++)
                {
                    if (fl == floors)
                    {
                        //last floor
                        Console.Write($"L{fl}{room} ");
                    }
                    else if (fl % 2 == 0) // even nums
                    {
                        Console.Write($"O{fl}{room} ");
                    }
                    else if (fl % 2 != 0) // odd nums
                    {
                        Console.Write($"A{fl}{room} ");
                    } 
                }
                //after we go through all the rooms on a floor we should go on the next line
                Console.WriteLine();
            }
        }
    }
}
