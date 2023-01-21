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
            Dictionary<string, Dictionary<string, int>> passwordContestAndUserPoints = new
                Dictionary<string, Dictionary<string, int>>();

            string command = string.Empty;

            while((command = Console.ReadLine()) != "end of contests")
            {
                string contestPassword = command;

                if (!passwordContestAndUserPoints.ContainsKey(contestPassword))
                {
                    passwordContestAndUserPoints.Add(contestPassword, new Dictionary<string, int>());
                }
            }

            string secondCommand = string.Empty;
            List<string> names = new List<string>();

            while ((secondCommand = Console.ReadLine()) != "end of submissions")
            {
                string[] userInfo = secondCommand
                    .Split(new string[] {"=>"}, StringSplitOptions.RemoveEmptyEntries);

                string contest = userInfo[0];
                string password = userInfo[1];
                string username = userInfo[2];
                int points = int.Parse(userInfo[3]);

                string contestAndPassword = contest + ':'+ password;

                if (passwordContestAndUserPoints.ContainsKey(contestAndPassword))
                {
                    if (!passwordContestAndUserPoints[contestAndPassword].ContainsKey(username))
                    {
                        passwordContestAndUserPoints[contestAndPassword][username] = 0;
                        
                        if (!names.Contains(username))
                        {
                            names.Add(username);
                        }
                    }

                    if (passwordContestAndUserPoints[contestAndPassword][username] < points)
                    {
                        passwordContestAndUserPoints[contestAndPassword][username] = points;
                    }
                } 
            }

            int sum = 0;
            int maxSum = 0;
            string bestStudent = string.Empty;
            Dictionary<string, Dictionary<string, int>> userAndContestPoints = new
                Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < names.Count; i++)
            {
                string name = names[i];

                foreach (var contest in passwordContestAndUserPoints)
                {
                    foreach (var user in contest.Value)
                    {
                        if (name == user.Key)
                        {
                            sum += user.Value;
                            
                            if (!userAndContestPoints.ContainsKey(name))
                            {
                                userAndContestPoints.Add(name, new Dictionary<string, int>());
                            }

                            if (!userAndContestPoints[name].ContainsKey(contest.Key.Split(':')[0]))
                            {
                                userAndContestPoints[name][contest.Key.Split(':')[0]] = user.Value;
                            }                        
                        }
                    }                    
                }

                if (maxSum < sum)
                {
                    maxSum = sum;
                    bestStudent = name;
                }

                sum = 0;
            }
           
            Console.WriteLine($"Best candidate is {bestStudent} with total {maxSum} points.");
            Console.WriteLine("Ranking:");

            foreach (var userName in userAndContestPoints
                .OrderBy(x => x.Key))           
            {              
                Console.WriteLine($"{userName.Key}");

                foreach (var contest in userName.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
