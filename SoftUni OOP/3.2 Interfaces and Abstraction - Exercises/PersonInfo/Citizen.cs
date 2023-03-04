using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string iD, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = iD;
            this.Birthdate = birthdate;
        }


        public string Name { get;  set; }
        public int Age { get; set;   }

        public string ID { get; set; }

        public string Birthdate { get; set; }
    }
}
