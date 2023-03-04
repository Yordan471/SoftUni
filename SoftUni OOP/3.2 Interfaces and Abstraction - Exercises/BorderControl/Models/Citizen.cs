using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Citizen : IPerson, IIdentifiable
    {
        public Citizen(string name, int age, string id)
        {
            Id = id;
            Name = name;
            Age = age;
        }


        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }
    }
}
