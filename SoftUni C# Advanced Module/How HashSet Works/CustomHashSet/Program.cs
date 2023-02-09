using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHashSet
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyHashSet myHashSet = new MyHashSet();

            myHashSet.Add("Gosho");
            myHashSet.Add("Peter");
            myHashSet.Add("Svilen");

            Console.WriteLine(myHashSet.Contains("Gosho"));
            Console.WriteLine(myHashSet.Contains("Spas"));
            

        }
    }
}
