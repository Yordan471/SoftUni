using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ListmanipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                List<string> strings = new List<string>();
                strings = command.Split().ToList();

                string operation = strings[0];
                int number = int.Parse(strings[1]);
                int index = 0;

                if (strings.Count == 3)
                {
                    index = int.Parse(strings[2]);
                }

                switch (operation)
                {
                    case "Add":
                        numbers.Add(number);
                        break;
                    case "Remove":
                        numbers.Remove(number);
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(number);
                        break;
                    case "Insert":
                        numbers.Insert(index, number);
                        break;
                }

                command = Console.ReadLine();
            }

                Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
