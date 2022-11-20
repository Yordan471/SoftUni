using System;
using System.Collections.Generic;
using System.Linq;

namespace Logs_Aggregator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLogs = int.Parse(Console.ReadLine());

            Dictionary <string, int> nameAndDuration = new Dictionary<string, int>();
            Dictionary <string, List<string>> nameAndIPs = new Dictionary<string, List<string>>();

            for (int i = 0; i < numberOfLogs; i++)
            {
                string[] accessLogs = Console.ReadLine()
                    .Split(' ');

                string iP = accessLogs[0];
                string name = accessLogs[1];
                int duration = int.Parse(accessLogs[2]);

                if (!nameAndIPs.ContainsKey(name))
                {
                    nameAndIPs.Add(name, new List<string>());
                    nameAndIPs[name].Add(iP);

                    nameAndDuration.Add(name, 0);
                }
                else if (!nameAndIPs[name].Contains(iP))
                {
                    nameAndIPs[name].Add(iP);
                }

                nameAndDuration[name] += duration;               
            }

            foreach (var nameIPs in nameAndIPs.OrderBy(x => x.Key))
            {
                Console.Write($"{nameIPs.Key}: ");

                int sumDuration = 0;

                foreach (var nameDuration in nameAndDuration)
                {
                    if (nameIPs.Key == nameDuration.Key)
                    {
                        sumDuration = nameDuration.Value;
                    }                   
                }

                Console.Write($"{sumDuration} ");
                
                List<string> logs = new List<string>();

                logs = nameIPs.Value.OrderBy(x => x).ToList();

                Console.WriteLine($"[{string.Join(", ", logs)}]");          
            }
        }
    }
}
