using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldest_Family_Member
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Family
    {
        List<string> people;
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
