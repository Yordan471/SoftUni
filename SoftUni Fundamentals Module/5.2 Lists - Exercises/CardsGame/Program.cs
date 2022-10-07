using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayerDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (firstPlayerDeck.Count != 0 && secondPlayerDeck.Count != 0)
            {

                for (int i = 0; i < Math.Min(firstPlayerDeck.Count, secondPlayerDeck.Count); i++)
                {
                    if (firstPlayerDeck[i] > secondPlayerDeck[i])
                    {
                        firstPlayerDeck.Add(firstPlayerDeck[i]);
                        firstPlayerDeck.RemoveAt(i);
                        firstPlayerDeck.Add(secondPlayerDeck[i]);
                        secondPlayerDeck.RemoveAt(i);
                    }
                    else if (secondPlayerDeck[i] > firstPlayerDeck[i])
                    {
                        secondPlayerDeck.Add(secondPlayerDeck[i]);
                        secondPlayerDeck.RemoveAt(i);
                        secondPlayerDeck.Add(firstPlayerDeck[i]);
                        firstPlayerDeck.RemoveAt(i);

                    }
                    else if (firstPlayerDeck[i] == secondPlayerDeck[i])
                    {
                        firstPlayerDeck.RemoveAt(i);
                        secondPlayerDeck.RemoveAt(i);
                    }

                    i--;
                }
            }

            int sum = 0;

            if (firstPlayerDeck.Count > 0)
            {
                for (int i = 0; i < firstPlayerDeck.Count; i++)
                {
                    sum += firstPlayerDeck[i];
                }

                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                for (int i = 0; i < secondPlayerDeck.Count; i++)
                {
                    sum += secondPlayerDeck[i];
                }

                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
