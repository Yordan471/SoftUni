using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstBoxInput = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondBoxInput = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> firstBox = new Queue<int>(firstBoxInput);
            Stack<int> secondBox = new Stack<int>(secondBoxInput);

            List<int> claimedItems = new List<int>();

            while (firstBox.Count != 0 && secondBox.Count != 0)
            {
                int firstItemLoot = firstBox.Peek();
                int secondItemLoot = secondBox.Peek();

                if ((firstItemLoot + secondItemLoot) % 2 == 0)
                {
                    int claimItem = firstItemLoot + secondItemLoot;

                    claimedItems.Add(claimItem);
                    firstBox.Dequeue();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Peek());
                }

                secondBox.Pop();
            }

            if (!firstBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (!secondBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
