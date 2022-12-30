using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regular = new HashSet<string>();
            HashSet<string> vip = new HashSet<string>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "PARTY")
            {
                string guestOrParty = command;

                if (guestOrParty.Length == 8)
                {
                    if (char.IsDigit(guestOrParty[0]))
                    {
                        vip.Add(guestOrParty);
                    }
                    else
                    {
                        regular.Add(guestOrParty);
                    }
                }
            }

            while ((command = Console.ReadLine()) != "END")
            {
                string resNumber = command;

                if (vip.Contains(resNumber))
                {
                    vip.Remove(resNumber);
                }
                else if (regular.Contains(resNumber))
                {
                    regular.Remove(resNumber);
                }
            }

            int countGuestsLeft = vip.Count + regular.Count;
            Console.WriteLine(countGuestsLeft);
            if (vip.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, vip));
            }

            if (regular.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, regular));
            }
            
        }
    }
}
