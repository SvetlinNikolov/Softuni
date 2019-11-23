using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CarDealerProfile>();

            });
            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                var inputXmlCars = File.ReadAllText("./../../../Datasets/cars.xml");
                var inputXmlCustomers = File.ReadAllText("./../../../Datasets/customers.xml");
                var inputXmlParts = File.ReadAllText("./../../../Datasets/parts.xml");
                var inputXmlSales = File.ReadAllText("./../../../Datasets/sales.xml");
                var inputXmlSuppliers = File.ReadAllText("./../../../Datasets/suppliers.xml");

                //Console.WriteLine(ImportSuppliers(db, inputXmlSuppliers));
                //Console.WriteLine(ImportParts(db, inputXmlParts));
                //Console.WriteLine(ImportCars(db, inputXmlCars));
                //Console.WriteLine(ImportCustomers(db, inputXmlCustomers));
                Console.WriteLine(ImportSales(db,inputXmlSales));
            }

        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSuppliersDto[]),
               new XmlRootAttribute("Suppliers"));

            var suppliersDto = (ImportSuppliersDto[])(xmlSerializer
                .Deserialize(new StringReader(inputXml)));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPartsDto[]),
               new XmlRootAttribute("Parts"));

            var partsDto = (ImportPartsDto[])(xmlSerializer
                .Deserialize(new StringReader(inputXml)));

            var parts = new List<Part>();

            foreach (var partDto in partsDto)
            {
                var part = Mapper.Map<Part>(partDto);

                if (context.Suppliers.Find(part.SupplierId) != null)
                {
                    parts.Add(part);
                }

            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {

            var xmlSerializer = new XmlSerializer(typeof(ImportCarsDto[]), new XmlRootAttribute("Cars"));
            var carsDto = (ImportCarsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Car> cars = new List<Car>();

            foreach (var carDto in carsDto)
            {
                var car = Mapper.Map<Car>(carDto);

                context.Cars.Add(car);

                foreach (var part in carDto.Parts.PartsId)
                {
                    if (car.PartCars
                        .FirstOrDefault(p => p.PartId == part.Id) == null &&
                        context.Parts.Find(part.Id) != null)
                    {
                        var partCar = new PartCar
                        {
                            CarId = car.Id,
                            PartId = part.Id
                        };

                        car.PartCars.Add(partCar);
                    }
                }

                cars.Add(car);
            }

            int count = context.SaveChanges();

            return $"Successfully imported {cars.Count()}";

        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {

            var xmlSerializer = new XmlSerializer(typeof(ImportCustomersDto[]),
               new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomersDto[])(xmlSerializer
                .Deserialize(new StringReader(inputXml)));

            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";

        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSalesDto[]),
              new XmlRootAttribute("Sales"));

            var salesDto = (ImportSalesDto[])(xmlSerializer
                .Deserialize(new StringReader(inputXml)));

            var sales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                if (context.Cars.Find(saleDto.CarId) != null)
                {
                    var sale = Mapper.Map<Sale>(saleDto);
                    sales.Add(sale);

                }
              

            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }
    }
}