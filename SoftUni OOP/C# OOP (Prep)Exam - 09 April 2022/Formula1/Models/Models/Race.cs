using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models.Models
{
    public class Race : IRace
    {
        private const int LessThen5Symbols = 5;
        private const int LessThen1Laps = 1;

        private string raceName;
        private int numberOfLaps;
        ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;

            pilots = new List<IPilot>();
            TookPlace = false;
        }

        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < LessThen5Symbols)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRaceName, value);
                }

                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if (value < LessThen1Laps)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidLapNumbers, value.ToString());)
                }

                numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }


        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The {this.RaceName} race haas:");
            sb.AppendLine($"Participants: {pilots.Count()}");
            sb.AppendLine($"Number of laps: {this.NumberOfLaps}");

            if (this.TookPlace == false)
            {
                sb.AppendLine($"Took place: No");
            }
            else
            {
                sb.AppendLine($"Took place: Yes");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
