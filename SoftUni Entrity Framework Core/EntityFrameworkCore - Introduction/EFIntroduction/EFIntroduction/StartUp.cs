
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var context = new SoftUniContext();

            //Console.WriteLine(GetEmployeesFullInformation(context));

            Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees;

            var employeesFullInformation = employees.AsNoTracking().OrderBy(e => e.EmployeeId);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesFullInformation)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees;

            int aboveSalary = 50000;

            var employeesSalaryOver50000 = employees
                .Where(e => e.Salary > aboveSalary)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();

            StringBuilder sb = new();

            foreach (var employee in employeesSalaryOver50000)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}