using FoodShortage.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();
            IBuyer person = null;

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (personInfo.Length == 4)
                {
                    string name = personInfo[0];
                    int age = int.Parse(personInfo[1]);
                    string id = personInfo[2];
                    string birthdate = personInfo[3];

                    person = new Citizen(name, age, id, birthdate);
                }
                else if (personInfo.Length == 3)
                {
                    string name = personInfo[0];
                    int age = int.Parse(personInfo[1]);
                    string group = personInfo[2];

                    person = new Rebel(name, age, group);
                }

                buyers.Add(person);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string name = command;

                foreach (IBuyer buyer in buyers)
                {
                    IPerson person1 = (IPerson)buyer;

                    if (person1.Name == name)
                    {
                        buyer.BuyFood();
                        break;
                    }
                }
            }

            Console.WriteLine(buyers.Sum(p => p.Food));
        }
    }
}
