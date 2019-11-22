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
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                //string inputJson = Console.ReadLine();
                Console.WriteLine(GetSoldProducts(db));


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
            var categoryProducts = new List<CategoryProduct>();
            categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.AddRange(categoryProducts.Select(x => x.Product.Seller)
                  .Where(x => x.FirstName != null && x.LastName != null));

            context.AddRange(categoryProducts.Select(x => x.Product.Buyer)
                .Where(x => x.FirstName != null && x.LastName != null));

            return $"Successfully imported {categoryProducts.Count}";


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

        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var userWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Count() >= 1 && u.ProductsSold.Select(ps => ps.Buyer) != null)
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

            return userWithSoldProducts.ToString();
        }
    }
}