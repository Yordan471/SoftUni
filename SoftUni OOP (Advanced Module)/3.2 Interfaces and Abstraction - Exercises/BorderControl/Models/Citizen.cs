using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Citizen : IMammal, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }


        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }
    }
}
