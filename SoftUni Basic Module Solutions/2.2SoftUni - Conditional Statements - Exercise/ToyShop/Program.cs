using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double puzzle, doll, bear, minion, kamion;

            puzzle = 2.6;
            doll = 3;
            bear = 4.10;
            minion = 8.20;
            kamion = 2;

            Console.Write("");
            double ExcursionPr = double.Parse(Console.ReadLine());

            Console.Write("");
            double puzzleBr = double.Parse(Console.ReadLine());

            Console.Write("");
            double dollBr = double.Parse(Console.ReadLine());

            Console.Write("");
            double bearBr = double.Parse(Console.ReadLine());

            Console.Write("");
            double minionBr = double.Parse(Console.ReadLine());

            Console.WriteLine("");
            double kamionBr = double.Parse(Console.ReadLine());
      
            double ToysSum = puzzleBr * puzzle + dollBr * doll + bearBr * bear + minionBr * minion + kamionBr * kamion;
            double ToysBr = puzzleBr + dollBr + bearBr + minionBr + kamionBr;
                     
            if (ToysBr >= 50 )
            {
               ToysSum = ToysSum - (ToysSum * 0.25);
            }
            double naem = ToysSum * 0.1;
            double sumLeft = ToysSum - naem;
            
            if (ExcursionPr > sumLeft)
            {                
                Console.WriteLine($"Not enough money! { ExcursionPr - sumLeft:f2} lv needed.");
            }
            else if (ExcursionPr <= sumLeft)
            {              
                Console.WriteLine($"Yes! {sumLeft - ExcursionPr:f2} lv left.");
            }             
        }      
    }
}
