using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guild
{
    public class Guild
    {
        private readonly ICollection<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MyProperty { get; set; }

        public int Count
        {
            get
            {
                return this.roster.Count;
            }
        }

        public IReadOnlyCollection<Player> Roster =>
            (IReadOnlyCollection<Player>)this.roster;

        public void AddPlayer(Player player)
        {
            if (this.Capacity > this.roster.Count)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (roster.Any(p => p.Name == name))
            {
                roster.Remove(roster.First(p => p.Name == name));
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            if (roster.Any(p => p.Name == name))
            {
                roster.First(p => p.Name == name).Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (roster.Any(p => p.Name == name))
            {
                roster.First(p => p.Name == name).Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classs)
        {
            Player[] removedPlayers = new Player[roster.Count(p => p.Class == classs)];
            int count = 0;

            foreach (var player in roster.Where(p => p.Class == classs))
            {
                removedPlayers[count] = player;
                count++;
            }

            foreach (var player in removedPlayers)
            {
                roster.Remove(player);
            }

            return removedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            if (roster.Count != 0)
            {
                foreach (var player in roster)
                {
                    sb.AppendLine($"{player}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
