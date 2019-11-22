using ProductShop.Data;
using ProductShop.Models;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Collections.Generic;
using ProductShop.Dtos.Import;
using AutoMapper;
using System.Linq;
using System.Text;
using System.Xml;
using ProductShop.Dtos.Export;

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
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputXmlUsers = File.ReadAllText("./../../../Datasets/users.xml");
                //var inputXmlProducts = File.ReadAllText("./../../../Datasets/products.xml");
                //var inputXmlCategories = File.ReadAllText("./../../../Datasets/categories.xml");
                //var inputXmlCategoriesProducts = File.ReadAllText("./../../../Datasets/categories-products.xml");
                //Console.WriteLine(ImportUsers(db, inputXmlUsers));
                //Console.WriteLine(ImportProducts(db, inputXmlProducts));
                //Console.WriteLine(ImportCategories(db, inputXmlCategories));
                //Console.WriteLine(ImportCategoryProducts(db, inputXmlCategoriesProducts));
                Console.WriteLine(GetUsersWithProducts(db));
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

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]),
                new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoryDto[])(xmlSerializer
                .Deserialize(new StringReader(inputXml)));

            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                if (categoryDto.Name != null)
                {
                    var category = Mapper.Map<Category>(categoryDto);
                    categories.Add(category);
                }
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";


        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]),
                new XmlRootAttribute("CategoryProducts"));

            var categoriesProductsDto = (ImportCategoryProductDto[])xmlSerializer
                .Deserialize(new StringReader(inputXml));

            var catProd = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoriesProductsDto)
            {
                var productId = context.Products.Find(categoryProductDto.ProductId);
                var categoryId = context.Categories.Find(categoryProductDto.CategoryId);

                if (productId != null && categoryId != null)
                {
                    var categoryProduct = Mapper.Map<CategoryProduct>(categoryProductDto);
                    catProd.Add(categoryProduct);
                }

            }
            context.CategoryProducts.AddRange(catProd);
            context.SaveChanges();
            return $"Successfully imported {catProd.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsWithingRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            var xmlSerializer =
                    new XmlSerializer(typeof(ProductsInRangeDto[]),
                    new XmlRootAttribute("Products"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), productsWithingRange, namespaces);

            return sb.ToString().TrimEnd();



        }

        //public static string GetSoldProducts(ProductShopContext context)
        //{

        //    var userWithSoldProducts = context
        //        .Users
        //        .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
        //  .Select(u => new ExportSoldProductDto
        //  {
        //      FirstName = u.FirstName,
        //      LastName = u.LastName,

        //      SoldProducts = u.ProductsSold.Select(p => new SoldProductDto
        //      {
        //          Name = p.Name,
        //          Price = p.Price
        //      })
        //       .ToArray()
        //  })
        //   .OrderBy(u => u.LastName)
        //   .ThenBy(u => u.FirstName)
        //   .Take(5)
        //   .ToArray();

        //    var xmlSerializer = new XmlSerializer(typeof(ExportSoldProductDto[]),
        //        new XmlRootAttribute("Users"));

        //    var sb = new StringBuilder();
        //    var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        //    xmlSerializer.Serialize(new StringWriter(sb), userWithSoldProducts, namespaces);

        //    return sb.ToString().TrimEnd();


        //}

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories

               .Select(c => new ExportCategoryByProductCountDto
               {
                   Name = c.Name,
                   Count = c.CategoryProducts.Count,
                   AveragePrice = (c.CategoryProducts

                   .Select(p => p.Product.Price)
                   .Average()),


                   TotalRevenue = (c.CategoryProducts
                   .Select(p => p.Product.Price)
                   .Sum())

               })
               .OrderByDescending(c => c.Count)
               .ThenBy(x => x.TotalRevenue)
               .ToArray();

            StringBuilder sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportCategoryByProductCountDto[]),
                new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersCount = context.Users
           .Where(x => x.ProductsSold.Count >= 1)
           .Count();

            var users = context
                         .Users
                         .Where(u => u.ProductsSold.Count > 0)
                         .OrderByDescending(u => u.ProductsSold.Count)
                         .Select(u => new UsersCountDto
                         {
                             Count = usersCount,

                             Users = null
                             //.Users
                             //.Where(usr => usr.ProductsSold.Count > 0)
                             //.Select(usr => new ExportSoldProductDto
                             //{
                             //    FirstName = usr.FirstName,
                             //    LastName = usr.LastName,
                             //    Age = usr.Age,

                             //    SoldProducts = context
                             //    .Users
                             //    .Where(sp => sp.ProductsSold.Count > 0)
                             //    .Select(sp => new UserProductsSoldDto
                             //    {
                             //        Count = sp.ProductsSold.Count(),

                             //        Products = usr.ProductsSold
                             //    .Select(user => new SoldProductDto
                             //    {
                             //        Name = user.Name,
                             //        Price = user.Price
                             //    })
                             //    .ToArray()
                             //    })
                             //    .ToArray()

                             //})
                             //.ToArray()
                         })
                         .ToArray();


            var xmlSerializer = new XmlSerializer(typeof(ExportSoldProductDto[]));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), users.ToArray(), namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
