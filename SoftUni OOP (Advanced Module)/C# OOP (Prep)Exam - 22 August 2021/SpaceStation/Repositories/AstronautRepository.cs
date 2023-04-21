using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly ICollection<IAstronaut> models;

        public AstronautRepository()
        {
            models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => models as IReadOnlyCollection<IAstronaut>;

        public void Add(IAstronaut model)
        {
            models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut astronaut = Models.FirstOrDefault(a => a.Name == name);

            return astronaut;
        }

        public bool Remove(IAstronaut model)
        {
            IAstronaut astronaut = Models.FirstOrDefault(a => a.Equals(model));

            return models.Remove(model);
        }
    }
}
