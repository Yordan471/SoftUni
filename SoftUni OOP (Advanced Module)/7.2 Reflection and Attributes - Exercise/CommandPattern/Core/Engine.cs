using CommandPattern.Core.Contracts;
using CommandPattern.IO.Contracts;
using CommandPattern.IO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private ICommandInterpreter interpreter;

        public Engine()
        {
            reader = new Reader();
            writer = new Writer();
        }

        public Engine(ICommandInterpreter interpreter) : this()
        {
            this.interpreter = interpreter;
        }

        public void Run()
        {
            while (true)
            {
                string inputLine = reader.ReadLine();
                string result = interpreter.Read(inputLine);
                this.writer.WriteLine(result);
            }
        }
    }
}
