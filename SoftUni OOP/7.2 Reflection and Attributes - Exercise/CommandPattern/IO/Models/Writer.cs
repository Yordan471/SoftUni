using CommandPattern.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.IO.Models
{
    public class Writer : IWriter
    {
        public void Write(object value)
        {
            Console.Write(value.ToString());
        }

        public void WriteLine(object value)
        {
            Console.WriteLine(value.ToString());
        }
    }
}
