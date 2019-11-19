using ProductShop.Data;
using ProductShop.Models;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Collections.Generic;
using ProductShop.Dtos.Import;
using AutoMapper;

namespace ProductShop
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ProductShopProfile>();
                
            });

            using (var db = new ProductShopContext())
            {

                //var inputXmlUsers = File.ReadAllText("./../../../Datasets/users.xml");
                var inputXmlProducts = File.ReadAllText("./../../../Datasets/products.xml");
                //Console.WriteLine(ImportUsers(db, inputXmlUsers));
                Console.WriteLine(ImportProducts(db, inputXmlProducts));
            }

        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]),
                new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])xmlSerializer
                .Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]),
                new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])(xmlSerializer
                  .Deserialize(new StringReader(inputXml)));

            List<Product> products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);
                products.Add(product);
            }
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
    }
}