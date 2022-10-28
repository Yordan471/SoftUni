using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Identification> identities = new List<Identification>();

            while (true)
            {
                if (command == "End")
                {
                    break;
                }

                string[] idInformation = command
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                Identification identity = new Identification(idInformation[0],
                    idInformation[1], idInformation[2]);

                identities.Add(identity);

                command = Console.ReadLine();
            }

            identities
                .OrderBy(identity => identity.Age)
                .ToList()
                .ForEach(identity => Console.WriteLine(identity));
        }
    }

    class Identification
    {
        public Identification(string name, string iD, string age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }

        public string ID { get; set; }  

        public string Age { get; set; }

        public override string ToString() => $"{Name} with ID: {ID} is {Age} years old.";
        
        
    }
}
