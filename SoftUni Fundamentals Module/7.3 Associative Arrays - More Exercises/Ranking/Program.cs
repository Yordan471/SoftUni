using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstInputInfo = Console.ReadLine();

            Dictionary<string, string> contestAndPassword = new Dictionary<string, string>();

            while (firstInputInfo != "end of contests")
            {
                string[] firstInputToArray = firstInputInfo
                    .Split(':');

                string contest = firstInputToArray[0];
                string passwordForContest = firstInputToArray[1];

                if (!contestAndPassword.ContainsKey(contest))
                {
                    contestAndPassword.Add(contest, passwordForContest);
                }
                else
                {
                    contestAndPassword[contest] = passwordForContest;
                }

                firstInputInfo = Console.ReadLine();
            }

            SortedDictionary<string, Dictionary<string, int>> contestNameWithPoints = new SortedDictionary<string, Dictionary<string, int>>();

            string secondInputToArray = string.Empty;

            while ((secondInputToArray = Console.ReadLine()) != "end of submissions")
            {
                string[] submissons = secondInputToArray
                    .Split("=>");

                string contest = submissons[0];
                string contestPassword = submissons[1];
                string studentName = submissons[2];
                int points = int.Parse(submissons[3]);

                if (contestAndPassword.ContainsKey(contest) &&
                    contestAndPassword[contest].Contains(contestPassword))
                {
                    if (!contestNameWithPoints.ContainsKey(studentName))
                    {
                        contestNameWithPoints.Add(studentName, new Dictionary<string, int>());
                        contestNameWithPoints[studentName].Add(contest, points);
                    }

                    if (contestNameWithPoints[studentName].ContainsKey(contest))
                    {
                        if (contestNameWithPoints[studentName][contest] < points)
                        {
                            contestNameWithPoints[studentName][contest] = points;
                        }
                    }
                    else
                    {
                        contestNameWithPoints[studentName].Add(contest, points);
                    }
                }         
            }

            Dictionary<string, int> highestPoints = new Dictionary<string, int>();

            foreach (KeyValuePair<string, Dictionary<string, int>> kvp in contestNameWithPoints)
            {
                highestPoints[kvp.Key] = kvp.Value.Values.Sum();
            }

            string highesPointsName = highestPoints
                .Keys
                .Max();

            int highesPoints = highestPoints
                .Values
                .Max();

            foreach (KeyValuePair<string, int> kvp in highestPoints)
            {
                if (kvp.Value == highesPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");
                }
            }

            Console.WriteLine("Ranking");

            foreach (var names in contestNameWithPoints)
            {
                Dictionary<string, int> namePoints = names.Value;
                namePoints = namePoints
                    .OrderByDescending(points => points.Value)
                    .ToDictionary(name => name.Key, points => points.Value);

                Console.WriteLine($"{names.Key}");

                foreach (KeyValuePair<string, int> kvp in namePoints)
                {
                    Console.WriteLine($"# {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
