using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public class Engine : IEngine
    {
        public void Run()
        {
            MathOperations operation = new();

            Console.WriteLine(operation.Add(1, 2));

            Console.WriteLine(operation.Add(2.2, 2.3, 2.4));

            Console.WriteLine(operation.Add(2.5M, 2.4M, 2.989492M));
        }
    }
}
