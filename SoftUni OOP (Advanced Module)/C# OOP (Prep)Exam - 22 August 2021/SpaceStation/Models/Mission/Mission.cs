using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (planet.Items.Count != 0 && astronauts.Any(a => a.Oxygen > 0))
            {
                foreach (var astronaut in astronauts.Where(a => a.Oxygen > 0))
                {
                    while (astronaut.Oxygen > 0)
                    {
                        if (planet.Items.Count != 0)
                        {
                            astronaut.Bag.Items.Add(planet.Items.First());
                            planet.Items.Remove(planet.Items.First());
                            astronaut.Breath();
                        }
                        else
                        {
                            break;
                        }
                    }                   
                }
            }            
        }
    }
}
