using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine()
                .Split(' ');

            Dictionary<string, Dictionary<string, HashSet<string>>> vloggerAndFollowedFollowers = 
                new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (commands[0] != "Statistics")
            {
                string vloggerName = commands[0];
                string operation = commands[1];
                string followedVLogger = commands[2];

                if (operation == "joined")
                {
                    if (!(vloggerAndFollowedFollowers.ContainsKey(vloggerName)))
                    {
                        vloggerAndFollowedFollowers[vloggerName] = new Dictionary<string, HashSet<string>>();
                    }
                }
                else if (operation == "followed" && 
                    vloggerAndFollowedFollowers.ContainsKey(followedVLogger) &&
                    vloggerAndFollowedFollowers.ContainsKey(vloggerName))
                {
                    if (!(vloggerAndFollowedFollowers[followedVLogger].ContainsKey(followedVLogger)))
                    {
                        vloggerAndFollowedFollowers[followedVLogger].Add(followedVLogger, new HashSet<string>());
                    }

                    if (vloggerName != followedVLogger)
                    {
                        vloggerAndFollowedFollowers[followedVLogger][followedVLogger].Add(vloggerName);
                    }                   
                }
            }
        }
    }
}
