
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {

                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                var inputJsonCars = File.ReadAllText("./../../../Datasets/cars.json");
                var inputJsonSuppliers = File.ReadAllText("./../../../Datasets/suppliers.json");
                var inputJsonCustomers = File.ReadAllText("./../../../Datasets/customers.json");
                var inputJsonParts = File.ReadAllText("./../../../Datasets/parts.json");
                var inputJsonSales = File.ReadAllText("./../../../Datasets/sales.json");

                //Console.WriteLine(ImportSuppliers(db, inputJsonSuppliers));
                //Console.WriteLine(ImportCars(db, inputJsonCars));

                //Console.WriteLine(ImportCustomers(db, inputJsonCustomers));
                //Console.WriteLine(ImportParts(db, inputJsonParts));
                //Console.WriteLine(ImportSales(db, inputJsonSales));
                Console.WriteLine(GetCarsFromMakeToyota(db));
            }
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.AddRange(suppliers);
            context.SaveChanges();

            return ($"Successfully imported {suppliers.Length}.");
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => p.SupplierId <= 31);

            context.Parts.AddRange(json);

            int count = context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<CarImportDTO[]>(inputJson);

            foreach (var carDto in cars)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,
                };
                context.Cars.Add(car);

                foreach (var part in carDto.PartsId)
                {
                    PartCar partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = part

                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == part) == null)
                    {
                        context.PartCars.Add(partCar);
                    }

                }

            }

            context.SaveChanges();

            return ($"Successfully imported {cars.Length}.");
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customer = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.AddRange(customer);
            context.SaveChanges();

            return ($"Successfully imported {customer.Length}.");
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.AddRange(sales);
            context.SaveChanges();

            return ($"Successfully imported {sales.Length}.");
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = string.Format("{0:dd/MM/yyyy}", c.BirthDate),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return result;

        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context
                .Cars
                .Where(c => c.Make.ToLower() == "toyota")
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c=> c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            var result = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);

            return result;
}

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliersNotImportingPartsFormAbroad = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            var result = JsonConvert.SerializeObject(suppliersNotImportingPartsFormAbroad);

            return result;

        }
    }
}