using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int countExploredPlanets = 0;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            
            foreach(var item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            if (!astronauts.Models.Any(a => a.Oxygen > 60))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = planets.FindByName(planetName);

            IMission mission = new Mission();
            //ICollection<IAstronaut> suitableAstronauts = astronauts.Models.Where(a => a.Oxygen > 60).ToList();
            mission.Explore(planet, astronauts.Models.Where(a => a.Oxygen > 60).ToList());
            countExploredPlanets++;

            int countDeadAstronauts = astronauts.Models.Count(a => a.CanBreath == false);

            return string.Format(OutputMessages.PlanetExplored, planetName, countDeadAstronauts);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{countExploredPlanets} planets were explored!{Environment.NewLine}");
            sb.Append($"Astronauts info:{Environment.NewLine}");

            foreach(var astronaut in astronauts.Models)
            {
                sb.Append($"Name: {astronaut.Name}{Environment.NewLine}");
                sb.Append($"Oxygen: {astronaut.Oxygen}{Environment.NewLine}");
                sb.Append($"Bag items: ");

                if (astronaut.Bag.Items.Count > 0)
                {
                    sb.Append($"{string.Join(", ", astronaut.Bag.Items)}{Environment.NewLine}");
                }
                else
                {
                    sb.Append($"none{Environment.NewLine}");
                }              
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
