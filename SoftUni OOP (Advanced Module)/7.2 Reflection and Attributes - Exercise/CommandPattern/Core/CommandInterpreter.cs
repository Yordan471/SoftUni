using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] splitArgs = args.Split(' ');
            string typeName = splitArgs[0];

            string[] invokeArgs = splitArgs
                .Skip(1)
                .ToArray();  

            Assembly assembly = Assembly.GetEntryAssembly();

            Type intendedCmdType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{typeName}Command");

            MethodInfo method = intendedCmdType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(m => m.Name == "Execute");

            object cmdInstance = Activator.CreateInstance(intendedCmdType);
            string result = (string)method.Invoke(cmdInstance, new object[] { splitArgs });

            return result;
        }
    }
}
