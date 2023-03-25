using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private ICollection<IHero> heroes;

        public HeroRepository()
        {
            heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => (IReadOnlyCollection<IHero>)heroes;

        public void Add(IHero model)
        {
            heroes.Add(model);
        }

        public IHero FindByName(string name)
        {
            return heroes.FirstOrDefault(h => h.Name == name);
        }

        public bool Remove(IHero model)
        {
            IHero heroToRemove = heroes.FirstOrDefault(h => h.Equals(model));

            if (heroToRemove != null)
            {
                heroes.Remove(heroToRemove);
                return true;
            }

            return false;
        }
    }
}
