using System;
using System.Collections.Generic;

namespace Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputInfo = string.Empty;

            Dictionary<string, Dictionary<string, int>> contestNameAndPoints =
                    new Dictionary<string, Dictionary<string, int>>();

            while ((inputInfo = Console.ReadLine()) != "no more time")
            {
                string[] inputInfoArray = inputInfo
                    .Split(" -> ");    

                string userName = inputInfoArray[0];
                string contest = inputInfoArray[1];
                int points = int.Parse(inputInfoArray[2]);

                if (!contestNameAndPoints.ContainsKey(contest))
                {
                    contestNameAndPoints.Add(contest, new Dictionary<string, int>());

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
                else
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
    }
}
