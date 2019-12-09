namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var projects = new List<Project>();

            var xmlSerializer = new XmlSerializer(typeof(ImportProjectsDto[]), new XmlRootAttribute("Projects"));
            var projectsDto = (ImportProjectsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var projectDto in projectsDto)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var projectDueDateNull = projectDto.DueDate;

                Project project = null;

                if (projectDueDateNull == "" || projectDueDateNull == null)
                {
                    project = new Project
                    {
                        Name = projectDto.Name,
                        OpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),


                    };
                }
                else
                {
                    project = new Project
                    {
                        Name = projectDto.Name,
                        OpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        DueDate = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),

                    };
                }



                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var taskOpenDate = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var taskDueDate = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var projectDueDate = project.DueDate;

                    if (project.DueDate == null)
                    {
                        projectDueDate = taskDueDate.AddDays(-1);
                    }
                    else
                    {
                        projectDueDate = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    var projectOpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    bool taskOpenDateBeforeProjectDate = DateTime.Compare(taskOpenDate, projectOpenDate) > 0;
                    bool taskDueDateAfterProjectDueDate = DateTime.Compare(taskDueDate, (DateTime)projectDueDate) < 0;

                    //bool executionTypeIsDefined = Enum.IsDefined(typeof(ExecutionType), taskDto.ExecutionType);
                    //bool labelTypeIsDefined = Enum.IsDefined(typeof(LabelType), taskDto.LabelType);

                    if (taskOpenDateBeforeProjectDate == false || taskDueDateAfterProjectDueDate == false
                       /* || executionTypeIsDefined == false || labelTypeIsDefined == false*/)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)Enum.Parse(typeof(ExecutionType), taskDto.ExecutionType),
                        LabelType = (LabelType)Enum.Parse(typeof(LabelType), taskDto.LabelType)
                    };

                    //maybe need to validate task with is valid well see
                    project.Tasks.Add(task);
                }
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
                projects.Add(project);
            }
            context.Projects.AddRange(projects);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeesDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var employees = new List<Employee>();

            foreach (var employeeDto in employeesDto)
            {
                var currentTasks = new List<Task>();

                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

              

                foreach (var taskDto in employeeDto.Tasks)
                {
                    if (context.Tasks.Find(int.Parse(taskDto))==null)
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                    else
                    {
                        if (currentTasks.FirstOrDefault(x => x.Id == int.Parse(taskDto)) == null)
                        {
                            Task task = new Task
                            {
                                Id = int.Parse(taskDto)
                            };

                            currentTasks.Add(task);
                          
                        }
                       
                    }
                }

                Employee employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                    EmployeesTasks = currentTasks.Select(et => new EmployeeTask { Task = et }).ToList()
                };
                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
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