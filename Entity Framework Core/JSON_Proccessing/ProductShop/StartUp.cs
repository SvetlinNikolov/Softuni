using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {

                //var inputJsonUsers = File.ReadAllText("./../../../Datasets/users.json");
                //var inputJsonProducts = File.ReadAllText("./../../../Datasets/products.json");
                //var inputJsonCategories = File.ReadAllText("./../../../Datasets/categories.json");
                //var inputJsonCategoriesProducts = File.ReadAllText("./../../../Datasets/categories-products.json");

                //Console.WriteLine(ImportUsers(db, inputJsonUsers));
                //Console.WriteLine(ImportProducts(db, inputJsonProducts));
                //Console.WriteLine(ImportCategories(db, inputJsonCategories));
                //Console.WriteLine(ImportCategoryProducts(db, inputJsonCategoriesProducts));
                Console.WriteLine(GetUsersWithProducts(db));


            }

        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson);

            var categoriesToInsert = categories.Where(x => x.Name != null);

            context.Categories.AddRange(categoriesToInsert);
            context.SaveChanges();

            return $"Successfully imported {categoriesToInsert.Count()}";


        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsWithingRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.price)
                .ToList();

            var serializedJson = JsonConvert.SerializeObject(productsWithingRange, Formatting.Indented);

            return serializedJson;

        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var userWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,

                    soldProducts = u.ProductsSold.Select(x => new
                    {
                        name = x.Name,
                        price = x.Price,
                        buyerFirstName = x.Buyer.FirstName,
                        buyerLastName = x.Buyer.LastName
                    })


                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName);

            var result = JsonConvert.SerializeObject(userWithSoldProducts, Formatting.Indented);

            return result.ToString();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = (c.CategoryProducts

                    .Select(p => p.Product.Price)
                    .Sum() /
                    c.CategoryProducts.Count).ToString("f2"),

                    totalRevenue = (c.CategoryProducts
                    .Select(p => p.Product.Price)
                    .Sum())
                    .ToString("f2")

                });

            var result = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return result.ToString();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
              .Where(x => x.ProductsSold.Count >= 1)
              .Count();

            var usersWithBuyer = context.Users
                .Where(x => x.ProductsSold.Count >= 1)
                .OrderByDescending(x => x.ProductsSold.Count)
                .Select(x => new
                {
                    usersCount = users,

                    users = context.Users
                    .Where(u => u.ProductsSold.Count >= 1)
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,

                        soldProducts = new
                        {
                            count = u.ProductsSold.Count(),

                            products = u.ProductsSold
                             .Where(p => p.Buyer != null)
                             .Select(ps => new
                             {
                                 name = ps.Name,
                                 price = ps.Price
                             })
                        }
                        
                    })
                });
               



            var result = JsonConvert.SerializeObject(usersWithBuyer, Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            return result;


        }
    }
}