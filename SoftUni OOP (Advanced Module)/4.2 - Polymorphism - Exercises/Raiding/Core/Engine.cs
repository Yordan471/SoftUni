using Raiding.Core.Interfaces;
using Raiding.HeroFactory.Interfaces;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IHeroFactory heroFactory;

        ICollection<IBaseHero> heroes;
        public Engine(IHeroFactory heroFactory)
        {
            this.heroFactory = heroFactory;

            heroes = new List<IBaseHero>();
        }

        public void Run()
        {
            int numberOfHeros = int.Parse(Console.ReadLine());

            while (heroes.Count != numberOfHeros) 
            {
                try
                {
                    heroes.Add(CreateHero());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            CastSpells();

            VictoryOrDefeat(bossPower);
        }

        private void VictoryOrDefeat(int bossPower)
        {
            if (heroes.Sum(h => h.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private void CastSpells()
        {
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
        }

        private IBaseHero CreateHero()
        {
            string name = Console.ReadLine();
            string heroType = Console.ReadLine();

            return heroFactory.Create(name, heroType);
        }
    }
}
