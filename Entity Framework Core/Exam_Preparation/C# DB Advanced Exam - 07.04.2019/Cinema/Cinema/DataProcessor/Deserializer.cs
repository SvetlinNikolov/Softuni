namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movies = JsonConvert.DeserializeObject<Movie[]>(jsonString);
            StringBuilder sb = new StringBuilder();

            var validMovies = new List<Movie>();

            foreach (var movie in movies)
            {
                var titleAlreadyExists = context.Movies.Select(x => x.Title == movie.Title).Count();
                var isValidGenre = Enum.IsDefined(typeof(Genre), movie.Genre);

                if (titleAlreadyExists != 0 || isValidGenre == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidMovie = IsValid(movie);

                if (isValidMovie)
                {

                    validMovies.Add(movie);
                    sb.AppendLine($"Successfully imported { movie.Title} with genre { movie.Genre} and rating { movie.Rating:f2}!");

                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsAndSeats = JsonConvert.DeserializeObject<ImportHallsAndSeatsDto[]>(jsonString);
            var sb = new StringBuilder();

            var validHalls = new List<Hall>();


            foreach (var hsDto in hallsAndSeats)
            {
                if (!IsValid(hsDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hsDto.Name,
                    Is4Dx = hsDto.Is4Dx,
                    Is3D = hsDto.Is3D

                };

                for (int i = 0; i < hsDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }
                string projType = CalculateProjectionType(hall);

                if (IsValid(hall))
                {
                    validHalls.Add(hall);
                    sb.AppendLine($"Successfully imported {hall.Name}({projType}) with {hall.Seats.Count} seats!");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }

            }
            context.Halls.AddRange(validHalls);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static string CalculateProjectionType(Hall hall)
        {
            string projType;
            if (hall.Is3D == true && hall.Is4Dx == true)
            {
                projType = "4Dx/3D";
            }
            else if (hall.Is3D == true)
            {
                projType = "3D";
            }
            else if (hall.Is4Dx == true)
            {
                projType = "4Dx";
            }
            else
            {
                projType = "Normal";
            }

            return projType;
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionsDto[]),
              new XmlRootAttribute("Projections"));

            var projectionsDto = (ImportProjectionsDto[])(xmlSerializer
                .Deserialize(new StringReader(xmlString)));

            var projections = new List<Projection>();

            foreach (var projDto in projectionsDto)
            {
                bool movieExists = context.Movies.Any(x => x.Id == projDto.MovieId);
                bool hallExists = context.Halls.Any(x => x.Id == projDto.HallId);

                if (!movieExists || !hallExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movieTitle = context.Movies.First(x => x.Id == projDto.MovieId);
                var Projection = new Projection
                {
                    MovieId = projDto.MovieId,
                    HallId = projDto.HallId,
                    DateTime = DateTime.ParseExact(projDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                if (!IsValid(Projection))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                projections.Add(Projection);
                sb.AppendLine($"Successfully imported projection {movieTitle.Title} on {Projection.DateTime.ToString("MM/dd/yyyy")}!");
            }
            context.Projections.AddRange(projections);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {

            StringBuilder sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ImportCustomersDto[]),
              new XmlRootAttribute("Customers"));

            var customerDtos = (ImportCustomersDto[])(xmlSerializer
                .Deserialize(new StringReader(xmlString)));

            var customers = new List<Customer>();

            foreach (var customerDto in customerDtos)
            {
                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                if (!IsValid(customer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customerTicketsProjectionIds = customerDto.Tickets.Select(x => x.ProjectionId).ToArray();

                bool projectionExists = context.Projections
                    .Select(x => x.Id)
                    .Except(customerTicketsProjectionIds)
                    .Any();

                if (projectionExists)
                {
                    foreach (var ticketDto in customerDto.Tickets)
                    {
                        var ticket = new Ticket
                        {
                            ProjectionId = ticketDto.ProjectionId,
                            Price = ticketDto.Price
                        };

                        customer.Tickets.Add(ticket);

                    }

                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket,
                    customer.FirstName,
                    customer.LastName,
                    customer.Tickets.Count()));

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}