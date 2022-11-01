using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputInfo = string.Empty;

            Dictionary<string, Dictionary<string, int>> contestNameAndPoints =
                    new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, Dictionary<string, int>> nameContestAndPoints = 
                new Dictionary<string, Dictionary<string, int>>();

            while ((inputInfo = Console.ReadLine()) != "no more time")
            {
                string[] inputInfoArray = inputInfo
                    .Split(" -> ");

                string userName = inputInfoArray[0];
                string contest = inputInfoArray[1];
                int points = int.Parse(inputInfoArray[2]);

                CheckIndividualPoints(nameContestAndPoints, userName, contest, points);

                if (!contestNameAndPoints.ContainsKey(contest))
                {
                    contestNameAndPoints.Add(contest, new Dictionary<string, int>());

                    CHeckIfInputInfoExists(contestNameAndPoints, userName,
                        contest, points);
                }
                else
                {
                    if (!contestNameAndPoints[contest].ContainsKey(userName))
                    {
                        contestNameAndPoints[contest].Add(userName, points);
                    }
                    else
                    {
                        if (contestNameAndPoints[contest][userName] < points)
                        {
                            contestNameAndPoints[contest][userName] = points;
                        }
                    }                 
                }
            }

            foreach (var contest in contestNameAndPoints)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count()} participants");
                int count = 0;

                Dictionary<string, int> userNameAndPoints = contest.Value;
                userNameAndPoints = userNameAndPoints
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var participant in userNameAndPoints)
                {             
                    count++;
                    Console.WriteLine($"{count}. {participant.Key} <::> {participant.Value}");
                }
            }

            Console.WriteLine($"Individual standings:");

            var sortedUsers = nameContestAndPoints.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key);
            int counter = 0;

            foreach (var user in sortedUsers)
            {
                counter++;
                Console.WriteLine($"{counter}. {user.Key} -> {user.Value.Values.Sum()}");
            }
        }

        private static void CheckIndividualPoints(Dictionary<string, Dictionary<string, int>> contestNameAndPointsTwo, string userName, string contest, int points)
        {
            if (!contestNameAndPointsTwo.ContainsKey(userName))
            {
                contestNameAndPointsTwo.Add(userName, new Dictionary<string, int>());
                contestNameAndPointsTwo[userName].Add(contest, points);
            }
            else
            {
                if (!contestNameAndPointsTwo[userName].ContainsKey(contest))
                {
                    contestNameAndPointsTwo[userName].Add(contest, points);
                }
                else
                {
                    if (contestNameAndPointsTwo[userName][contest] < points)
                    {
                        contestNameAndPointsTwo[userName][contest] = points;
                    }
                }
            }
        }

        private static void CHeckIfInputInfoExists(Dictionary<string, Dictionary<string, int>> contestNameAndPoints, string userName, string contest, int points)
        {
            if (!contestNameAndPoints[contest].ContainsKey(userName))
            {
                contestNameAndPoints[contest][userName] = points;
            }
            else
            {
                if (!(contestNameAndPoints[contest][userName] < points))
                {
                    contestNameAndPoints[contest][userName] = points;
                }
            }
        }
    }
}
