using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team()
        {
            this.Name = string.Empty;
            this.OpenPositions = 0;
            this.Group = 'a';
        }

        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
        }
        public string Name { get; set; }

        public int OpenPositions { get; set; }

        public char Group { get; set; }

        public int Count
        {
            get
            {
                return Players.Count;
            }
        }

        public List<Player> Players { get; set; } = new List<Player>();

        public string AddPlayer(Player player)
        {
            if (player.Name == null || player.Name == string.Empty ||
                player.Position == null || player.Position == string.Empty)
            {
                return $"Invalid player's information.";
            }
            else if (OpenPositions == 0)
            {
                return $"There are no more open positions.";
            }
            else if (player.Raiting < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                Players.Add(player);
                OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
            }
        }

        public bool RemovePlayer(string name)
        {
            if (Players.Any(p => p.Name.Equals(name)))
            {
                Players.Remove(Players.First(p => p.Name.Equals(name)));
                OpenPositions++;
                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            List<Player> removePlayers = new List<Player>();
            
            foreach (Player player in Players)
            {
                removePlayers.Add(player);
            }

            int countRemovedPlayers = 0;

            if (Players.Any(p => p.Position.Equals(position)))
            {
                foreach (Player player in Players)
                {
                    if (player.Position.Equals(position))
                    {
                        removePlayers.Remove(player);
                        countRemovedPlayers++;
                    }
                }

                Players = removePlayers;
                OpenPositions += countRemovedPlayers;
                return countRemovedPlayers;
            }

            return 0;
        }

        public Player RetirePlayer(string name)
        {
            Player retiredPlayer = new Player();

            if (Players.Any(p => p.Name.Equals(name)))
            {
                foreach (Player player in Players)
                {
                    if (player.Name.Equals(name))
                    {
                        player.Retired = true;
                        retiredPlayer = player;
                        OpenPositions++;
                    }
                }

                return retiredPlayer;
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> listPlatersAboveNumberOfGames = new List<Player>();

            foreach (Player player in Players)
            {
                if (player.Games >= games)
                {
                    listPlatersAboveNumberOfGames.Add(player);
                }
            }

            return listPlatersAboveNumberOfGames;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {this.Name} from Group {Group}:");

            foreach (Player player in Players)
            {
                sb.AppendLine($"{player}");
            }
            
            return sb.ToString().Trim();
        }
    }
}
