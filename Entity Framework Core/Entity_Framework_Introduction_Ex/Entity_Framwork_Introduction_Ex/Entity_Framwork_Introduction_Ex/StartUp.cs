using SoftUni.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = IncreaseSalaries(context);
            Console.WriteLine(result);


        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                            .Employees
                            .Select(e => new
                            {
                                Id = e.EmployeeId,
                                Name = string.Join(" ", e.FirstName, e.LastName, e.MiddleName),
                                e.JobTitle,
                                e.Salary
                            })
                            .OrderBy(e => e.Id)
                            .ToList();



            foreach (var empl in employees)
            {
                sb.AppendLine($"{empl.Name} {empl.JobTitle} {empl.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                            .Employees
                            .Select(e => new
                            {
                                Name = e.FirstName,
                                Salary = e.Salary

                            })
                            .Where(s => s.Salary > 50000)
                            .OrderBy(e => e.Name)
                            .ToList();

            foreach (var empl in employees)
            {
                sb.AppendLine($"{empl.Name} - {empl.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext
context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                            .Employees
                            .Select(e => new
                            {
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Salary = e.Salary,
                                Department = e.Department.Name

                            })
                            .Where(e => e.Department == "Research and Development")
                            .OrderBy(s => s.Salary)
                            .ThenByDescending(s => s.FirstName)
                            .ToList();

            foreach (var empl in employees)
            {
                sb.AppendLine($"{empl.FirstName } { empl.LastName} from {empl.Department} - ${empl.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                     .Where(e => e.EmployeesProjects
                     .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                     .Take(10)
                     .Select(e => new
                     {
                         e.FirstName,
                         e.LastName,
                         ManagerFirstName = e.Manager.FirstName,
                         ManagerLastName = e.Manager.LastName,
                         Projects = e.EmployeesProjects
                             .Select(ep => ep.Project)
                     })
                     .ToList();


            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Projects)
                {

                    sb.AppendLine($"--{p.Name} -" +
                                    $" {p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - " +
                                    $"{(p.EndDate == null ? "not finished" : p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))}");
                }



            }
            return sb.ToString().TrimEnd();

        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var empAdrr = context
                 .Addresses
                 .Select(a => new
                 {
                     EmployeeCount = a.Employees.Count,
                     TownName = a.Town.Name,
                     AddressText = a.AddressText
                 })
                 .OrderByDescending(a => a.EmployeeCount)
                 .ThenBy(a => a.TownName)
                 .ThenBy(a => a.AddressText)
                 .Take(10)
                 .ToList();

            foreach (var ea in empAdrr)
            {
                sb.AppendLine($"{ea.AddressText}, {ea.TownName} - {ea.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context
               .Employees
              .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects
                    .Select(ep => ep.Project.Name)
                    .OrderBy(p => p)
                    .ToList(),

                    EmployeeId = e.EmployeeId
                })
                .First();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            sb.AppendLine(string.Join(Environment.NewLine, employee.Projects));


            return sb.ToString().TrimEnd();



        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departmentsAndEmployees = context
                 .Departments
                 .Select(d => new

                 {
                     EmployeeCount = d.Employees.Count,
                     DepartmentName = d.Name,
                     DepartmentManager = string.Join(" ", d.Manager.FirstName, d.Manager.LastName),
                     Employees = d.Employees
                     .Select(e => new
                     {
                         EmployeeFullName = string.Join(" ", e.FirstName, e.LastName),
                         EmplJobTitle = e.JobTitle,
                         EmployeeFirstName = e.FirstName,
                         EmployeeLastName = e.LastName
                     })

                 })
                 .Where(d => d.EmployeeCount > 5)
                 .OrderBy(d => d.EmployeeCount)
                 .ThenBy(d => d.DepartmentName)
                 .Take(5)
                 .ToList();

            foreach (var de in departmentsAndEmployees)
            {
                sb.AppendLine($"{de.DepartmentName} - {de.DepartmentManager}");

                foreach (var e in de.Employees.OrderBy(em => em.EmployeeFirstName).ThenBy(em => em.EmployeeLastName))
                {
                    sb.AppendLine($"{e.EmployeeFullName} - {e.EmplJobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var latestProjects = context
                .Projects
                .Select(p => new
                {
                    ProjectStartDate = p.StartDate,
                    ProjectName = p.Name,
                    ProjectDiscription = p.Description

                })
                .OrderByDescending(p => p.ProjectStartDate)
                .Take(10)
                .ToList();

            foreach (var p in latestProjects.OrderBy(p => p.ProjectName))
            {
                sb.AppendLine($"{p.ProjectName}")
                .AppendLine(p.ProjectDiscription)
                .AppendLine(p.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();

        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            context.Employees
             .Where(e =>
               e.Department.Name == "Engineering" ||
               e.Department.Name == "Tool Design" ||
               e.Department.Name == "Marketing"   ||
               e.Department.Name == "Information Services")
                       .ToList()
                       .ForEach(e => e.Salary *= 1.12m);

            context.SaveChanges();

            var empl = context
         .Employees
         .Select(e => new
         {
             EmplFirstName = e.FirstName,
             EmplLastName = e.LastName,
             EmplSalary = e.Salary,
             EmplDepartment = e.Department
         })
         .Where(e =>
         e.EmplDepartment.Name == "Engineering" ||
         e.EmplDepartment.Name == "Tool Design" ||
         e.EmplDepartment.Name == "Marketing" ||
         e.EmplDepartment.Name == "Information Services")
         .ToList();


            foreach (var e in empl.OrderBy(e=> e.EmplFirstName).ThenBy(e=> e.EmplLastName))
            {
                sb.AppendLine($"{e.EmplFirstName} {e.EmplLastName} (${e.EmplSalary:f2})");
            }

            return sb.ToString().TrimEnd();

        }
    }
}