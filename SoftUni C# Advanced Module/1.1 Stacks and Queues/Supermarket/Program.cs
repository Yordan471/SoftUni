using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            Queue<string> costumers = new Queue<string>();

            while ((command = Console.ReadLine()) != "End")
            {
                if (command != "Paid")
                {
                    costumers.Enqueue(command);
                }
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, costumers));
                    costumers.Clear();
                }
            }

            Console.WriteLine($"{costumers.Count} people remaining.");            
        }
    }
}
