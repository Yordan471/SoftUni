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
            Dictionary<string, Dictionary<string, string>> forceSideAndForceUser = new
                Dictionary<string, Dictionary<string, string>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                if (command.Contains('|'))
                {
                    string[] inputInfo = command
                    .Split(new string[] {" | "}, StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = inputInfo[0];
                    string forceUser = inputInfo[1];
                    bool exists = false;

                    if (!forceSideAndForceUser.ContainsKey(forceSide))
                    {
                        foreach (var user in forceSideAndForceUser.Values)
                        {
                            if (user.Keys.Contains(forceUser))
                            {
                                exists = true;
                                continue;
                            }                          
                        }

                        if (exists == false)
                        {
                            forceSideAndForceUser.Add(forceSide, new Dictionary<string, string>());
                            forceSideAndForceUser[forceSide].Add(forceUser, forceSide);
                            exists = false;
                        }
                        
                    }
                    else if (!forceSideAndForceUser[forceSide].ContainsKey(forceUser))
                    {
                        forceSideAndForceUser[forceSide].Add(forceUser, forceSide);
                    }
                }
                else if (command.Contains("->"))
                {
                    string[] inputInfo = command
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                    string forceUser = inputInfo[0];
                    string forceSide = inputInfo[1];

                    if (!forceSideAndForceUser.ContainsKey(forceSide))
                    { 
                        forceSideAndForceUser.Add(forceSide, new Dictionary<string, string>());
                        forceSideAndForceUser[forceSide].Add(forceUser, forceSide);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                    else if (!forceSideAndForceUser[forceSide].ContainsKey(forceUser))
                    {
                        forceSideAndForceUser[forceSide][forceUser] = forceSide;
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }

                    foreach (var forceside in forceSideAndForceUser)
                    {
                        if (forceside.Key != forceSide)
                        {
                            if (forceSideAndForceUser[forceside.Key].ContainsKey(forceUser))
                            {
                                forceSideAndForceUser[forceside.Key].Remove(forceUser);
                            }
                        }
                    }                   
                }
            }

            foreach (var forceSidee in forceSideAndForceUser
                .OrderByDescending(x => x.Value.Count())
                .ThenBy(x => x.Key))
            {
                if (forceSidee.Value.Count() > 0)
                {
                    Console.WriteLine($"Side: {forceSidee.Key}, Members: {forceSidee.Value.Count()}");

                    foreach (var forceuser in forceSidee.Value.Keys.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {forceuser}");
                    }
                }            
            }
        }
    }
}
