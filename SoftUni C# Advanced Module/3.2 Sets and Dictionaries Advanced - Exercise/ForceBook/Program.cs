using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Dictionary<string, int>, Dictionary<string, int>> asd = new
                Dictionary<Dictionary<string, int>, Dictionary<string, int>>();

            if (!asd.ContainsKey(new Dictionary<string, int>()))
            {
                asd.Add(new Dictionary<string, int>(), Dictionary<string, int>());
            }
        }
    }
}
