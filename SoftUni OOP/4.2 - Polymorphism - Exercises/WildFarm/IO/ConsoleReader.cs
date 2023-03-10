using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.IO.Interfaces;

namespace WildFarm.IO
{
    public class ConsoleReader : IReader
    {
        public void ReadLine(string str)
        {
            Console.ReadLine();
        }
    }
}
