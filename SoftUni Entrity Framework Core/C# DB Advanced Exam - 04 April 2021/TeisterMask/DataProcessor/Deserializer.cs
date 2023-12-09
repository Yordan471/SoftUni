// ReSharper disable InconsistentNaming

namespace TeisterMask.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using TeisterMask.Utilities;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models;
    using System.Text;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            string xmlRootName = "Projects";

            ImportXmlProjectDto[] projectDtos = xmlHelper.Deserialize<ImportXmlProjectDto[]>(xmlString, xmlRootName);

            ICollection<Project> validProjects = new HashSet<Project>();
            StringBuilder sb = new();

            foreach (var projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime parseOpenDate;
                bool isValidOpenDate = DateTime.TryParseExact(
                    projectDto.OpenDate, 
                    "dd/MM/yyyy", 
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, 
                    out parseOpenDate);

                if (!isValidOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime parseDueDate;
                bool isValidDueDate = DateTime.TryParseExact(
                    projectDto.OpenDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out parseDueDate);

                Project validProject = new()
                {
                    Name = projectDto.Name,
                    OpenDate = parseOpenDate,
                    DueDate = parseDueDate
                };

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime parseTaskOpenDate;
                    bool isValidTaskOpenDate = DateTime.TryParseExact(
                        projectDto.OpenDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out parseTaskOpenDate);

                    DateTime parseTaskDueDate;
                    bool isValidTaskDueDate = DateTime.TryParseExact(
                        projectDto.OpenDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out parseTaskDueDate);

                    if (!isValidTaskOpenDate || !isValidTaskDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (parseTaskOpenDate < parseOpenDate || parseTaskDueDate > parseDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task validTask = new()
                    {
                        Name = taskDto.Name,
                        OpenDate = parseTaskOpenDate,
                        DueDate = parseTaskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };

                    validProject.Tasks.Add(validTask);
                }

                validProjects.Add(validProject);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, validProject.Name, validProject.Tasks.Count));
            }

            context.Projects.AddRange(validProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            ImportJsonEmployeeDto[] employeeDtos = 
                JsonConvert.DeserializeObject<ImportJsonEmployeeDto[]>(jsonString);

            ICollection<Employee> validEmployees = new HashSet<Employee>();
            StringBuilder sb = new();

            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee validEmployee = new()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    Task existingTask = context.Tasks.Find(taskId);

                    if (existingTask != null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validEmployee.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Employee = validEmployee,
                        TaskId = taskId,
                    });
                }

                validEmployees.Add(validEmployee);
                sb.AppendLine(string.Format(
                    SuccessfullyImportedEmployee, validEmployee.Username, validEmployee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}