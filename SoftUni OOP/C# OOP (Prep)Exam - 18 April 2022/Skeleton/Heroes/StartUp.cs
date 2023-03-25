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
            IHero hero = new Hero("Pesho", 100, 50);
            IWeapon Mace = new Mace("Pesho's Weapon", 15);

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
