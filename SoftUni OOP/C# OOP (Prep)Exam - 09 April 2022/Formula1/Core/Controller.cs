﻿using Formula1.Core.Contracts;
using Formula1.Models.Contracts;
using Formula1.Models.Models;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository formulaOneCarRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            formulaOneCarRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (!pilotRepository.Models.Any(p => p.FullName == pilotName) ||
                pilotRepository.Models.Any(p => p.FullName == pilotName && p.Car != null))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar formulaCar = formulaOneCarRepository.Models
                .FirstOrDefault(c => c.Model == carModel);

            if (formulaCar == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            IPilot pilot = pilotRepository.FindByName(pilotName);
            pilot.AddCar(formulaCar);
            formulaOneCarRepository.Remove(formulaCar);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, formulaCar.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot pilot = pilotRepository.FindByName(pilotFullName);

            if (pilot == null || pilot.CanRace == false || race.Pilots.Any(p => p.Equals(pilot)))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = formulaOneCarRepository.Models
                .FirstOrDefault(m => m.Model == model);

            if (car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            if (type == nameof(Ferrari))
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == nameof(Williams))
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            formulaOneCarRepository.Add(car);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = pilotRepository.FindByName(fullName);

            if (pilot == null)
            {
                pilotRepository.Add(pilot);
                return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
            }

            throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            throw new NotImplementedException();
        }

        public string RaceReport()
        {
            StringBuilder sb = new();

            foreach (var race in raceRepository.Models.Where(r => r.TookPlace == true))
            {
                sb.AppendLine($"{race.RaceInfo()}");
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count() < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
          
            StringBuilder sb = new();
            IPilot[] firstThreePilots = new IPilot[3];
            int countPilts = 0;

            foreach (var pilot in race.Pilots
                .OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps))
                .Take(3))               
            {
                firstThreePilots[countPilts] = pilot;
                countPilts++;
            }

            race.TookPlace = true;
            firstThreePilots[0].WinRace();

            sb.AppendLine($"Pilot {firstThreePilots[0].FullName} wins the {race.RaceName} race.");
            sb.AppendLine($"Pilot {firstThreePilots[1].FullName} is second in the {race.RaceName} race.");
            sb.AppendLine($"Pilot {firstThreePilots[2].FullName} is third in the {race.RaceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
