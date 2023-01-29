using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        List<Person> people = null;

        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }

        void AddMember(Person person)
        {
            People.Add(person);
        }

        public Person GetOldestMember(List<Person> People)
        {
            return People
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
        }
    }
}
