using SoftUni.Data;
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
            string result = GetEmployeesFromResearchAndDevelopment(context);
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
                            .ThenByDescending(s=> s.FirstName)
                            .ToList();

            foreach (var empl in employees)
            {
                sb.AppendLine($"{empl.FirstName } { empl.LastName} from {empl.Department} - ${empl.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
