using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MOBAChallenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerPositionAndSKill =
                new Dictionary<string, Dictionary<string, int>>();

            string inputInfo = string.Empty;
            string firstSeparator = " -> ";
            string secondSeparator = " vs ";

            while ((inputInfo = Console.ReadLine()) != "Season end")
            {
                string[] inputInfoToArray = null;

                if (inputInfo.Contains(firstSeparator))
                {
                    inputInfoToArray = inputInfo
                        .Split(firstSeparator,
                        StringSplitOptions.RemoveEmptyEntries);

                    AddingPlayerOrUpdateInfo(playerPositionAndSKill, inputInfoToArray);
                }
                else if (inputInfo.Contains(secondSeparator))
                {
                    inputInfoToArray = inputInfo
                        .Split(secondSeparator,
                        StringSplitOptions.RemoveEmptyEntries);

                    string firstPlayer = inputInfoToArray[0];
                    string secondPlayer = inputInfoToArray[1];

                    if (playerPositionAndSKill.ContainsKey(firstPlayer) &&
                        playerPositionAndSKill.ContainsKey(secondPlayer))
                    {
                        PlayerVsPlayer(playerPositionAndSKill, firstPlayer, secondPlayer);
                    }
                }
            }

            Dictionary<string, Dictionary<string, int>> orderByPointsThenName =
                    playerPositionAndSKill
                    .OrderByDescending(x => x.Value.Values.Sum())
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

            PrintOutputInformation(orderByPointsThenName);
        }

        private static void AddingPlayerOrUpdateInfo(Dictionary<string, Dictionary<string, int>> playerPositionAndSKill, string[] inputInfoToArray)
        {
            string addPlayer = inputInfoToArray[0];
            string position = inputInfoToArray[1];
            int skillPoints = int.Parse(inputInfoToArray[2]);

            if (!playerPositionAndSKill.ContainsKey(addPlayer))
            {
                playerPositionAndSKill.Add(addPlayer, new Dictionary<string, int>());
                playerPositionAndSKill[addPlayer].Add(position, skillPoints);
            }
            else
            {
                if (!playerPositionAndSKill[addPlayer].ContainsKey(position))
                {
                    playerPositionAndSKill[addPlayer].Add(position, skillPoints);
                }
                else
                {
                    if (playerPositionAndSKill[addPlayer][position] < skillPoints)
                    {
                        playerPositionAndSKill[addPlayer][position] = skillPoints;
                    }
                }
            }
        }

        private static void PlayerVsPlayer(Dictionary<string, Dictionary<string, int>> playerPositionAndSKill, string firstPlayer, string secondPlayer)
        {
            bool toBreak = false;

            foreach (var first in playerPositionAndSKill[firstPlayer])
            {
                foreach (var second in playerPositionAndSKill[secondPlayer])
                {
                    if (first.Key == second.Key)
                    {
                        if (playerPositionAndSKill[firstPlayer].Sum(x => x.Value) <
                            playerPositionAndSKill[secondPlayer].Sum(x => x.Value))
                        {
                            playerPositionAndSKill.Remove(firstPlayer);
                            toBreak = true;
                            break;
                        }
                        else if (playerPositionAndSKill[firstPlayer].Sum(x => x.Value) >
                            playerPositionAndSKill[secondPlayer].Sum(x => x.Value))
                        {
                            playerPositionAndSKill.Remove(secondPlayer);
                            toBreak = true;
                            break;
                        }
                    }
                }

                if (toBreak)
                {
                    break;
                }
            }
        }

        private static void PrintOutputInformation(Dictionary<string, Dictionary<string, int>> orderByPointsThenName)
        {
            foreach (var player in orderByPointsThenName)
            {
                int totalSkillPoints = player.Value.Values.Sum();
                Console.WriteLine($"{player.Key}: {totalSkillPoints} skill");

                Dictionary<string, int> orderBySkillAndPosition =
                    player.Value;
                orderBySkillAndPosition = orderBySkillAndPosition
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var skill in orderBySkillAndPosition)
                {
                    Console.WriteLine($"- {skill.Key} <::> {skill.Value}");
                }
            }
        }
    }
}
