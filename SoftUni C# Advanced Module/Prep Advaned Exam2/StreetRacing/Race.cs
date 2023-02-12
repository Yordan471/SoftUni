using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public List<Car> Participants { get; set; }

        public int Count
        {
            get
            {
                return Participants.Count;
            }
        }

        public void Add(Car car)
        {
            bool addCar = true;

            if (this.Count < this.Capacity &&
                car.HorsePower <= MaxHorsePower)
               
            {
                foreach (var participant in Participants)
                {
                    if (participant.LicensePlate == car.LicensePlate)
                    {
                        addCar = false;
                        break;
                    }
                }

                if (addCar)
                {
                    Participants.Add(car);
                }              
            }
        }

        public bool Remove(string licensePlate)
        {
            if (Participants.Any(c => c.LicensePlate == licensePlate))
            {
                Car removeCar = Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
                Participants.Remove(removeCar);
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            if (Participants.Any(c => c.LicensePlate == licensePlate))
            {
                Car returnCar = Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
                return returnCar;
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Count == 0)
            {
                return null;
            }

            Car mostPowerfulCar = Participants.OrderByDescending(c => c.HorsePower).FirstOrDefault();

            return mostPowerfulCar;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            
            if (Participants.Count > 0)
            {
                foreach (Car car in Participants)
                {
                    sb.AppendLine(car.ToString());
                }
            }
            
            return sb.ToString().Trim();
        }
    }
}
