using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.IO
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            throw new NotImplementedException();
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            throw new NotImplementedException();
        }

        public string ColorEgg(string eggName)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
