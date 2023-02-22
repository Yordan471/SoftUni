using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {       
        public string RemoveString()
        {
            Random random = new Random();

            return this[random.Next(0, Count)];
        }
    }
}
