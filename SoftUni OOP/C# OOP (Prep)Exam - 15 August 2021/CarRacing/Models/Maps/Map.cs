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
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }

            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }

            if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            racerOne.Race();
            racerTwo.Race();
            decimal firstRacerWinChances = 0;
            decimal secondRacerWinChances = 0;

            if (racerOne.RacingBehavior == "strict")
            {
                firstRacerWinChances = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2M;
            }
            else
            {
                firstRacerWinChances = racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1M;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                secondRacerWinChances = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.2M;
            }
            else
            {
                secondRacerWinChances = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.1M;
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
