using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int interval = int.Parse(Console.ReadLine());

            bool opened = false;
            bool balanced = true;
            //    bool saveBalance = false;

            for (int i = 1; i <= interval; i++)
            {
                string command = Console.ReadLine();

                if (command == "(")
                {
                    if (!opened)
                    {
                        opened = true;
                    }
                    else
                    {
                        balanced = false;
                    }
                }
                else if (command == ")")
                {
                    if (opened)
                    {
                        opened = false;
                    }
                    else
                    {
                        balanced = false;
                    }
                }
            }

            if (opened == false && balanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
