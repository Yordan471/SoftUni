using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var context = new SoftUniContext();

            //Console.WriteLine(GetEmployeesFullInformation(context));

            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            //Console.WriteLine(AddNewAddressToEmployee(context));

            //Console.WriteLine(GetEmployeesInPeriod(context));

            //Console.WriteLine(GetAddressesByTown(context));

            //Console.WriteLine(GetEmployee147(context));

            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

            Console.WriteLine(GetLatestProjects(context));
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

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees;

            string department = "Research and Development";

            var employeesFromRAndD = employees
                .Where(e => e.Department.Name == department)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            //var employeesFromSpecificDepartment = employees
            //    .Join(context.Departments, e => e.DepartmentId, d => d.DepartmentId, (e, d) => new 
            //{
            //    e.FirstName,
            //    e.LastName,
            //    d.Name,
            //    e.Salary
            //})
            //    .Where(e => e.Name == department)
            //    .OrderBy(e => e.Salary)
            //    .ThenByDescending(e => e.FirstName)
            //    .ToArray();

            StringBuilder sb = new();

            foreach (var employee in employeesFromRAndD)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var employees = context.Employees;

            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };


            string searchedName = "Nakov";

            var findEmployee = employees.FirstOrDefault(e => e.LastName == searchedName);

            findEmployee!.Address = address;

            context.SaveChanges();

            var tenAddressesText = employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new
                {
                    e.Address.AddressText
                }).ToArray();

            StringBuilder sb = new();

            foreach (var employee in tenAddressesText)
            {
                sb.AppendLine(employee.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees;

            var employeesInPeriod = employees
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager!.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                               .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                               .Select(ep => new
                               {
                                   ProjectName = ep.Project.Name,
                                   StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                   EndDate = ep.Project.EndDate.HasValue ?
                                             ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                               }
                               ).ToArray()
                }
                ).ToArray();

            StringBuilder sb = new();

            foreach (var employee in employeesInPeriod)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                if (employee.Projects.Any())
                {
                    foreach (var project in employee.Projects)
                    {
                        sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses;

            var findTenAddresses = addresses
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town!.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)                             
                .Select(a => new 
                {
                    a.AddressText,
                    TownName = a.Town!.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .ToArray();

            StringBuilder sb = new();

            foreach (var address in findTenAddresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .Where(e => e.EmployeeId == 147)                
                .FirstOrDefault();

            //var emp = context.Employees.Where(e => e.EmployeeId == 147).Select(e => e.EmployeesProjects.Select(ep => ep.Project)).ToArray();

            StringBuilder sb = new();

            sb.AppendLine($"{employee!.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var employeeProject in employee.EmployeesProjects.OrderBy(ep => ep.Project.Name))
            {
                sb.AppendLine($"{employeeProject.Project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(e => e.Departments)
                .Where(e => e.Department.Employees.Count() > 5)
                .OrderBy(e => e.Department.Employees.Count())
                .ThenBy(e => e.Department.Name)
                .Select(d => new
                {
                    DepartmentName = d.Department.Name,
                    ManageerName = d.Manager.FirstName + d.Manager.LastName,
                    Employees = d.Department.Employees
                })
                .ToArray();
                 
                

            StringBuilder sb = new();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.DepartmentName} - {employee.ManageerName}");
                string DepName = employee.DepartmentName;

                foreach (var emp in employee.Employees
                    
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }

                Console.WriteLine(sb.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    ProjectName = p.Name,
                    ProjectDescription = p.Description,
                    ProjectStartDate = p.StartDate
                });

            StringBuilder sb = new();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.ProjectName}");
                sb.AppendLine($"{project.ProjectDescription}");
                sb.AppendLine($"{project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}