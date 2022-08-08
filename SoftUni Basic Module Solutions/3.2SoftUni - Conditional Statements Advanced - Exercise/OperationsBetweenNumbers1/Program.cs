using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsBetweenNumbers1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal N1 = decimal.Parse(Console.ReadLine());
            decimal N2 = decimal.Parse(Console.ReadLine());
            string operate = Console.ReadLine();

            decimal result = 0.00M;
            string output = string.Empty;

            if (N2 == 0 && (operate == "/" || operate == "%"))
            {
                output = string.Format("Cannot divide {0} by zero", N1);
            }
            else if (operate == "/")
            {
                result = N1 / N2;
                output = string.Format("{0} {1} {2} = {3:f2}", N1, operate, N2, result);
            }
            else if (operate == "%")
            {
                result = N1 % N2;
                output = string.Format("{0} {1} {2} = {3}", N1, operate, N2, result);
            }
            else
            {
                if (operate == "+")
                {
                    result = N1 + N2;
                }
                else if (operate == "-")
                {
                    result = N1 - N2;
                }
                else if (operate == "*")
                {
                    result = N1 * N2;
                }
                output = string.Format("{0} {1} {2} = {3} - {4}", N1, operate, N2, result, 
                    result % 2 == 0 ? "even" : "odd");
            }
            Console.WriteLine(output);
        }
    }
}
