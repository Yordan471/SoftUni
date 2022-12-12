using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company_Roster
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] employeeInfo = Console.ReadLine()
                    .Split(' ');

                string name = employeeInfo[0];
                decimal salary = decimal.Parse(employeeInfo[1]);
                string department = employeeInfo[2];

                Employee employee = new Employee(name, salary, department);

                employees.Add(employee);
            }

            decimal highestSalary = 0;            
            string saveDepartment = string.Empty;

            foreach (Employee employee in employees)
            {
                string dep = employee.Department;
                decimal sumSalary = 0;

                foreach (Employee department in employees)
                {
                    if (department.Department == dep)
                    {
                        sumSalary += department.Salary;
                    }
                }
                
                if (sumSalary > highestSalary)
                {
                    highestSalary = sumSalary;
                    saveDepartment = dep;
                }
            }                

            Console.WriteLine($"Highest Average Salary: {saveDepartment}");

            foreach (Employee employee1 in employees.OrderByDescending(e => e.Salary))
            {
                if (employee1.Department == saveDepartment )
                {
                    Console.WriteLine($"{employee1.Name} {employee1.Salary:f2}");
                }
            }
        }
    }

    public class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }
    }
}
