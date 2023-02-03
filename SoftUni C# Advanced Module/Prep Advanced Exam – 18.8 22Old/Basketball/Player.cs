using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Basketball
{
    public class Player
    {
        public Player()
        {
            this.Name = string.Empty;
            this.Position = string.Empty;
            this.Raiting = 0;
            this.Games = 0;
            this.Retired = false;
        }

        public Player (string name, string position, double raiting, int games)
            : this()
        {
            this.Name = name;
            this.Position = position;
            this.Raiting = raiting;
            this.Games = games;
        }
        public string Name { get; set; }

        public string Position { get; set; }

        public double Raiting { get; set; }

        public int Games { get; set; }

        public bool Retired { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player: {Name}");
            sb.AppendLine($"--Position: {Position}");
            sb.AppendLine($"--Raiting: {Raiting:f2}");
            sb.AppendLine($"Games player: {Games}");

            return sb.ToString().Trim();
        }
    }
}
