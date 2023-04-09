using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance |
                BindingFlags.Public | BindingFlags.Static);

            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(m => m.AttributeType == typeof(AuthorAttribute)))
                {
                    var attrubutes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute atribute in attrubutes)
                    {
                        Console.WriteLine($"{method.Name} is written by {atribute.Name}");
                    }
                }
            }
        }
    }
}
