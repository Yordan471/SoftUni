﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityOfTheFood = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Console.WriteLine(orders.Max());

            while (orders.Count != 0 && orders.Peek() <= quantityOfTheFood)
            {
                quantityOfTheFood -= orders.Dequeue();
            }

            if (orders.Count > 0)
            {
                Console.Write($"Orders left: ");
                Console.WriteLine(string.Join(" ", orders));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
