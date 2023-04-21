using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] fields)
        {
            Type type = Type.GetType(nameOfClass);
            FieldInfo[] fieldsInfo = type.GetFields(BindingFlags.Static | BindingFlags.Public |
                BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            Object instnceOfType = Activator.CreateInstance(type, new object[] { });

            sb.AppendLine($"Class under investigation: {nameOfClass}");

            foreach (FieldInfo field in fieldsInfo.Where(f => fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instnceOfType)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type givenClass = Type.GetType(className);
            FieldInfo[] fields = givenClass.GetFields(BindingFlags.Static |
                BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] publicMethods = givenClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] privateMethods = givenClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new();

            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach(MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            foreach (MethodInfo method in privateMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type typeClass = Type.GetType(className);

            MethodInfo[] privateMethods = typeClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new();

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {typeClass.BaseType.Name}");

            foreach(MethodInfo method in privateMethods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type getClass = Type.GetType(className);

            MethodInfo[] methods = getClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);


            StringBuilder sb = new();

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} wil return {method.ReturnType}");
            }
            

            return sb.ToString().TrimEnd();
        }
    }
}
