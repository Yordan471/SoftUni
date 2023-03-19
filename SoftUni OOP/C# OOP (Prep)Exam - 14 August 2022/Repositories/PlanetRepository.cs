using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets;

        public void AddItem(IPlanet model)
        {
            this.planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = planets.FirstOrDefault(p => p.Name == name);

            if (planet == null)
            {
                return null;
            }

            return planet;
        }

        public bool RemoveItem(string name) => this.planets.Remove(this.planets.FirstOrDefault(x => x.Name == name));
    }
}
