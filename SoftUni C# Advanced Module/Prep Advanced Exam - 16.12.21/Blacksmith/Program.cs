using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] steelInput = Console.ReadLine()
                .Split()
                .Select(s => int.Parse(s))
                .ToArray();

            int[] carbonInput = Console.ReadLine()
               .Split()
               .Select(s => int.Parse(s))
               .ToArray();

            Queue<int> steel = new Queue<int>(steelInput);
            Stack<int> carbon = new Stack<int>(carbonInput);

            Dictionary<int, string> valueAndSwords = new Dictionary<int, string>()
            {
                { 70, "Gladius" },
                { 80, "Shamshir" },
                { 90, "Katana" },
                { 110, "Sabre" },
                { 150, "Broadsword" }
            };

            Dictionary<string, int> swordsAndAmout = new Dictionary<string, int>();

            while (steel.Count != 0 && carbon.Count != 0)
            {
                int forgeSwordValue = steel.Peek() + carbon.Peek();

                if (valueAndSwords.ContainsKey(forgeSwordValue))
                {
                    string sword = valueAndSwords[forgeSwordValue];

                    if (!swordsAndAmout.ContainsKey(sword))
                    {
                        swordsAndAmout.Add(sword, 0);
                    }

                    swordsAndAmout[sword]++;
                    carbon.Pop();
                }
                else
                {
                    int saveCarbon = carbon.Pop() + 5;
                    carbon.Push(saveCarbon);
                }

                steel.Dequeue();
            }

            if (swordsAndAmout.Any())
            {
                Console.WriteLine($"You have forged {swordsAndAmout.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Any())
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var sword in swordsAndAmout.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
