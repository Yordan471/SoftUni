using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfUsernames = int.Parse(Console.ReadLine());

            HashSet<string> users = new HashSet<string>();

            for (int i = 0; i < numberOfUsernames; i++)
            {
                users.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, users));
        }
    }
}
