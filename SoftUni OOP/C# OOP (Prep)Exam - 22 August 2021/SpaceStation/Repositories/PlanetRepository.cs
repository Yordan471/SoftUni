using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => models as IReadOnlyCollection<IPlanet>;

        public void Add(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet astronaut = Models.FirstOrDefault(a => a.Name == name);

            return astronaut;
        }

        public bool Remove(IPlanet model)
        {
            IPlanet astronaut = Models.FirstOrDefault(a => a.Equals(model));

            return models.Remove(model);
        }
    }
}
