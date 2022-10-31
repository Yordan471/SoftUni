using System;
using System.Collections.Generic;

namespace Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputInfo = string.Empty;

            Dictionary<string, Dictionary<string, List<int>>> contestNameAndPoints =
                    new Dictionary<string, Dictionary<string, List<int>>>();

            while ((inputInfo = Console.ReadLine()) != "no more time")
            {
                string[] inputInfoArray = inputInfo
                    .Split(" -> ");    

                string userName = inputInfoArray[0];
                string contest = inputInfoArray[1];
                int points = int.Parse(inputInfoArray[2]);


            }


        }
    }
}
