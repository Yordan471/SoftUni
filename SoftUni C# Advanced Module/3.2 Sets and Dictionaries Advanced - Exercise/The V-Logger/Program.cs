using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary<string, Dictionary<string, HashSet<string>>> vloggerAndFollowers = new
                Dictionary<string, Dictionary<string, HashSet<string>>>();


            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] vloggerInfo = command
                    .Split(' ');

                string vloggerName = vloggerInfo[0];
                string action = vloggerInfo[1];

                if (action == "joined")
                {
                    if (!vloggerAndFollowers.ContainsKey(vloggerName))
                    {
                        vloggerAndFollowers.Add(vloggerName, new Dictionary<string, HashSet<string>>());

                        vloggerAndFollowers[vloggerName].Add("followers", new HashSet<string>());
                        vloggerAndFollowers[vloggerName].Add("following", new HashSet<string>());
                    }
                }
                else if (action == "followed")
                {
                    string followedVlogger = vloggerInfo[2];

                    if (vloggerAndFollowers.ContainsKey(vloggerName) &&
                        vloggerAndFollowers.ContainsKey(followedVlogger) &&
                        vloggerName != followedVlogger)
                    {
                        vloggerAndFollowers[vloggerName]["following"].Add(followedVlogger);
                        vloggerAndFollowers[followedVlogger]["followers"].Add(vloggerName);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggerAndFollowers.Count} vloggers in its logs.");

            int counter = 1;

            foreach (var vloggerFollowers in vloggerAndFollowers
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{counter}. {vloggerFollowers.Key} : {vloggerFollowers.Value["followers"].Count} followers," +
                    $" {vloggerFollowers.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (string follower in vloggerFollowers.Value["followers"])
                    {
                        Console.WriteLine($"* {follower}");
                    }
                }

                counter++;
            }
        }
    }
}
