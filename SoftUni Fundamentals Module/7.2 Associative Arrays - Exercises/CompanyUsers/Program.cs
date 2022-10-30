using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputInformation = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<string>> companyEmployeeId = new Dictionary<string, List<string>>();

            while (inputInformation[0] != "End")
            {
                string companyName = inputInformation[0];
                string employeeId = inputInformation[1];

                if (!companyEmployeeId.ContainsKey(companyName))
                {
                    companyEmployeeId.Add(companyName, new List<string>() { employeeId });
                }
                else
                {
                    if (!companyEmployeeId[companyName].Contains(employeeId))
                    {
                        companyEmployeeId[companyName].Add(employeeId);
                    }               
                }

                inputInformation = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (KeyValuePair<string, List<string>> employee in companyEmployeeId)
            {
                Console.WriteLine($"{employee.Key}");

                for (int i = 0; i < employee.Value.Count; i++)
                {
                    Console.WriteLine($"-- {employee.Value[i]}");
                }
            }
        }
    }
}
