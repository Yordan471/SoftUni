using System;

namespace challengeWedding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int manClients = int.Parse(Console.ReadLine());
            int womenClients = int.Parse(Console.ReadLine());
            int maxNumTables = int.Parse(Console.ReadLine());

            int counter = 0;
            int letter = 0;

            for (int i =1; i <= manClients; i++)
            {
                for (int j = 1; j <= womenClients; j++)
                {
                    counter++;
                    if (counter > maxNumTables)
                    {
                        break;
                    }

                    Console.Write($"({i} <-> {j}) ");
                    letter = j;
                }

                if (counter == maxNumTables)
                {
                    break;
                }
            }            
        }      
    }
}
