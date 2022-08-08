using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsBetweenNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            decimal N1 = decimal.Parse(Console.ReadLine());
            decimal N2 = decimal.Parse(Console.ReadLine());
            string operate = Console.ReadLine();

            decimal result = 0;

            if (operate == "/")
            {
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else
                {
                    result = N1 / N2;
                    Console.WriteLine($"{N1} / {N2} = {result}");
                }
            }
            if (operate == "+")
            {
                result = N1 + N2;
                {
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{N1} + {N2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} + {N2} = {result} - odd");
                    }
                }
            }
            if (operate == "-")
            {
                result = N1 - N2;
                {
                    if(result % 2 == 0)
                    {
                        Console.WriteLine($"{N1} - {N2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} - {N2} = {result} - odd");
                    }
                }
            }
            if (operate == "*")
            {
                result = N1 * N2;
                {
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{N1} * {N2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} * {N2} = {result} - odd");
                    }
                }
            }
            if (operate == "%")
            {
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else
                {
                    result = N1 % N2;
                    Console.WriteLine($"{N1} % {N2} = {result}");
                }
            }          
        }
    }
}
