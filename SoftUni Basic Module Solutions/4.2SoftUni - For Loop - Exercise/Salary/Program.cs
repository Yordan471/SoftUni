using System;

namespace Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
           
            int Facebook = 150; int Instagram = 100;
            int Reddit = 50;

            for (int i = 1; i <= n; i++)
            {
                string website = Console.ReadLine();
                switch (website)
                {
                    case "Facebook":
                        salary -= Facebook; break;
                    case "Instagram":
                        salary -= Instagram; break;
                    case "Reddit":
                        salary -= Reddit; break;
                }
            }           
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine($"{salary}");
            }
        }
    }
}
