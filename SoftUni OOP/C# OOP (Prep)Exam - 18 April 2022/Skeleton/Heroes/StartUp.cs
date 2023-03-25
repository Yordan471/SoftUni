using System;
using Heroes.Core;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;

namespace Heroes
{
    public class StartUp
    {
        public static void Main()
        {
            IHero hero = new Barbarian("Pesho", 100, 50);
            IWeapon Mace = null;

            hero.AddWeapon(Mace);
            Console.WriteLine(hero.Weapon);

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
