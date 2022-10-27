using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace TeamworkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] teamInformation = Console.ReadLine()
                    .Split('-')
                    .ToArray();

                string creator = teamInformation[0];
                string teamName = teamInformation[1];

                if (teams.Any(team => team.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(team => team.User == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Team team = new Team(teamInformation[0], teamInformation[1]);
                    teams.Add(team);
                }
                
            }

            string command = Console.ReadLine();

            while (true)
            {
                if (command == "end of assignment")
                {
                    break;
                }

                string[] commandToArray = command
                    .Split("->")
                    .ToArray();

                string member = commandToArray[0];
                string teamName = commandToArray[1];
                
                if ()
            }

        }
    }

    class Team
    {
        public Team(string user, string teamName)
        {
            this.User = user;
            this.TeamName = teamName;
        }

        public string User { get; set; }

        public string TeamName { get; set; }    

        List <string> M { get; set; }

        public bool CheckIfTeamExists(List<Team> teams, string[] teamInformation)
        {

        }
    }
}
