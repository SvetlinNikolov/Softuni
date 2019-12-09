namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context
                .Projects
                .Where(p => p.Tasks.Count() > 0)
                .OrderByDescending(x => x.Tasks.Count())
                .ThenBy(x => x.Name)
                .Select(p => new ExportProjectsDto
                {
                    TasksCount = p.Tasks.Count().ToString(),
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",

                    Tasks = p.Tasks.Select(x => new ExportTasksDto
                    {
                        Name = x.Name,
                        Label = x.LabelType.ToString()
                    })
                    .OrderBy(x => x.Name)
                .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProjectsDto[]), new XmlRootAttribute("Projects"));


            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            StringBuilder sb = new StringBuilder();

            //Order the employees by all tasks count(descending), then by username(ascending).

            var employees = context
                  .Employees
                  .Where(e => e.EmployeesTasks.Count() > 0
                  && e.EmployeesTasks.Any(x => DateTime.Compare(x.Task.OpenDate, date) >= 0))
                .OrderByDescending(e => e.EmployeesTasks.Where(x => DateTime.Compare(x.Task.OpenDate, date) >= 0).Count())
                .ThenBy(e => e.Username)
                  .Take(10)
                  .Select(e => new
                  {
                      Username = e.Username,

                      Tasks = e.EmployeesTasks.Where(et => DateTime.Compare(et.Task.OpenDate, date) >= 0)
                      .Select(x => new
                      {
                          TaskName = x.Task.Name,
                          OpenDate = x.Task.OpenDate.ToString("d",CultureInfo. InvariantCulture),
                          DueDate = x.Task.DueDate.ToString("d",CultureInfo.InvariantCulture),
                          LabelType = x.Task.LabelType.ToString(),
                          ExecutionType = x.Task.ExecutionType.ToString()

                      })
                      .OrderByDescending(x => DateTime.ParseExact( x.DueDate, "d",CultureInfo.InvariantCulture))
                      .ThenBy(x => x.TaskName)
                      .ToArray()
                  })

                  .ToArray();


            var json = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return json;

        }
    }
}