using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Dictionary<string, string>, Dictionary<string, int>> passwordContestAndUserPoints = new
                Dictionary<Dictionary<string, string>, Dictionary<string, int>>();

            string command = string.Empty;

            while((command = Console.ReadLine()) != "end of contests")
            {
                string[] contestInfo = command
                    .Split(':');

                string contestName = contestInfo[0];
                string password = contestInfo[1];

                foreach (var contestPassword in passwordContestAndUserPoints.Keys)
                {
                    if(!contestPassword.ContainsKey(contestName))
                    {
                        contestPassword.Add(contestName, password);
                    }
                }
            }

            string secondCommand = string.Empty;

            while ((secondCommand = Console.ReadLine()) != "end of submissions")
            {
                string[] userInfo = secondCommand
                    .Split(new string[] {"=>"}, StringSplitOptions.RemoveEmptyEntries);

                string contest = userInfo[0];
                string password = userInfo[1];
                string username = userInfo[2];
                int points = int.Parse(userInfo[3]);

                foreach (var contestPassword in passwordContestAndUserPoints)
                {                  
                    if (contestPassword.Key.ContainsKey(contest))
                    {
                        if (contestPassword.Key[contest] == password)
                        {
                            if (!contestPassword.Value.ContainsKey(username))
                            {
                                contestPassword.Value.Add(username, 0);
                            }

                            contestPassword.Value[username] += points;                           
                        }
                    }                 
                }
            }
        }
    }
}
