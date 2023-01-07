using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> addVAT =
                x => x * 1.2m;

            List<decimal> prices = Console.ReadLine()
                .Split(',')
                .Select(p => decimal.Parse(p))
                .Select(addVAT)
                .ToList();
           
            prices.ForEach(p => Console.WriteLine($"{p:f2}"));
        }
    }
}
