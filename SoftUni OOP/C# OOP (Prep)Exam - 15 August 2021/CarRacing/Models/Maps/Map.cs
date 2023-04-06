using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne == null && racerTwo == null)
            {
                return "Race cannot be completed because both racers are not available!";
            }

            if (racerOne == null)
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }

            if (racerTwo == null)
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            racerOne.Race();
            racerTwo.Race();
            double firstRacerWinChances = 0;
            double secondRacerWinChances = 0;

            if (racerOne.RacingBehavior == "strict")
            {
                firstRacerWinChances = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2;
            }
            else
            {
                firstRacerWinChances = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                secondRacerWinChances = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.2;
            }
            else
            {
                secondRacerWinChances = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.1;
            }

            if (secondRacerWinChances > firstRacerWinChances)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
            }
            else
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }
        }
    }
}
