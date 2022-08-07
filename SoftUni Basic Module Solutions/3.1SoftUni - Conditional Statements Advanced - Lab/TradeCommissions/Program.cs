using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCommissions
{
    public class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sells = double.Parse(Console.ReadLine());

            double commissionS = 0.0;
            double commissionV = 0.0;
            double commissionP = 0.0;

            if (sells >= 0 && sells <= 500)
            {
                commissionS += 0.05; commissionV += 0.045; commissionP += 0.055;
            }
            else if (sells >= 500 && sells <=1000)
            {
                commissionS += 0.07; commissionV += 0.075; commissionP += 0.08;
            }
            else if (sells >= 1000 && sells <= 10000)
            {
                commissionS += 0.08; commissionV += 0.1; commissionP += 0.12;
            }
            else if (sells > 10000)
            {
                commissionS += 0.12; commissionV += 0.13; commissionP += 0.145;                                              
            }
            else
            {
                Console.WriteLine("error");
                return;
            }
            double commSofSum = sells * commissionS;
            double commVarSum = sells * commissionV;
            double commPlovSum = sells * commissionP;

            switch (city)
            {
                case ("Sofia"):
                    Console.WriteLine($"{commSofSum:f2}"); break;
                case ("Varna"):
                    Console.WriteLine($"{commVarSum:f2}"); break;
                case ("Plovdiv"):
                    Console.WriteLine($"{commPlovSum:f2}"); break;
                    default:
                    Console.WriteLine("error"); break;
            }
        }
    }
}
