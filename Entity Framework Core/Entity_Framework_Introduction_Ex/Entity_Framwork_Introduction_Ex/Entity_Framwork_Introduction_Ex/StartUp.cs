using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            string result = DeleteProjectById(context);
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

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address address = new Address();
            address.TownId = 4;
            address.AddressText = "Vitoshka 15";

            context.Addresses.Add(address);

            context.Employees
                   .First(e => e.LastName == "Nakov")
                   .Address = address;

            context.SaveChanges();

            var employees = context
                            .Employees
                            .Select(e => new
                            {
                                Name = e.FirstName,
                                AddressId = e.AddressId,
                                AddressText = e.Address.AddressText

                            })
                            .OrderByDescending(e => e.AddressId)
                            .Take(10)
                            .ToList();

            foreach (var empl in employees)
            {
                sb.AppendLine($"{empl.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var empl = context
                .Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .Where(e => e.FirstName.StartsWith("Sa"))
                .ToList();

            foreach (var e in empl.OrderBy(e=> e.FirstName).ThenBy(e=> e.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projectToDelete = context
                .Projects
                .First(p => p.ProjectId == 2);

            context.EmployeesProjects.ToList().ForEach(ep => context.EmployeesProjects.Remove(ep));
           
            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context
                .Projects
                .Select(p => new
                {
                    ProjectName = p.Name
                })
                .Take(10)
                .ToList();

            foreach (var proj in projects)
            {
                sb.AppendLine(proj.ProjectName);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
