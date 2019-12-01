namespace Cinema.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var topMovies = context
                 .Movies
                 .Where(m => m.Rating >= rating && m.Projections.Any(t => t.Tickets.Count() > 0))
                 .OrderByDescending(m => m.Rating)
                 .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                 .Select(m => new
                 {
                     MovieName = m.Title,
                     Rating = m.Rating.ToString("f2"),
                     TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("f2"),

                     Customers = m.Projections
                     .SelectMany(t => t.Tickets
                     .Select(c => c.Customer)
                     .Select(x => new
                     {
                         FirstName = x.FirstName,
                         LastName = x.LastName,
                         Balance = x.Balance.ToString("f2")
                     })
                     .OrderByDescending(c => c.Balance)
                                .ThenBy(c => c.FirstName)
                                .ThenBy(c => c.LastName))
                     .ToList()

                 })

                 .Take(10)
                 .ToList();

            var json = JsonConvert.SerializeObject(topMovies, Formatting.Indented);

            return json;


        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context
                 .Customers
                 .Where(c => c.Age >= age)
                 .OrderByDescending(c => c.Tickets.Sum(t => t.Price))
                 .Select(c => new ExportCustomersDto
                 {
                     FirstName = c.FirstName,
                     LastName = c.LastName,
                     SpentMoney = c.Tickets.Sum(t => t.Price).ToString("f2"),

                     SpentTime = TimeSpan.FromSeconds(c.Tickets
                    .Sum(t => t.Projection.Movie.Duration.TotalSeconds))
                    .ToString(@"hh\:mm\:ss")
        })
                 .Take(10)
                 .ToArray();

        var xmlSerializer = new XmlSerializer(typeof(ExportCustomersDto[]), new XmlRootAttribute("Customers"));
        StringBuilder sb = new StringBuilder();

        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
    }
}
}