using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Shopping_Spree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> personList = CreatePersonWithMoney();

            List<Product> productList = CreateProductWithPrice();

            while (true)
            {
                string[] personAndProductToBuy = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (personAndProductToBuy[0] == "END")
                {
                    break;
                }

                var currentPerson = personList.FirstOrDefault(x => x.Name == personAndProductToBuy[0]);
                var currentProduct = productList.FirstOrDefault(x => x.Name == personAndProductToBuy[1]);

                if (productList.Contains(currentProduct))
                {
                    if (currentPerson != null)
                    {
                        try
                        {
                            currentPerson.BuyProduct(currentProduct);
                            Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                        }
                        catch (Exception ae)
                        {

                            Console.WriteLine(ae.Message);
                        }
                    }
                }

            }

            foreach (var person in personList)
            {
                Console.WriteLine(person.ToString());
            }

        }

        private static List<Product> CreateProductWithPrice()
        {
            string[] products = Console.ReadLine()
                                       .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Product> productList = new List<Product>();

            foreach (var item in products)

            {
                string[] productAndCost = item.Split("=", StringSplitOptions.RemoveEmptyEntries);

                string currentProduct = productAndCost[0];
                decimal currentCost = decimal.Parse(productAndCost[1]);

                Product product = new Product(currentProduct, currentCost);
                productList.Add(product);

            }

            return productList;
        }

        private static List<Person> CreatePersonWithMoney()
        {
            string[] people = Console.ReadLine()
                            .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> personList = new List<Person>();

            foreach (var item in people)

            {
                string[] personAndMoney = item.Split("=", StringSplitOptions.RemoveEmptyEntries);

                string currentPerson = personAndMoney[0];
                decimal currentMoney = decimal.Parse(personAndMoney[1]);

                try
                {
                    Person person = new Person(currentPerson, currentMoney);
                    personList.Add(person); 
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }

            return personList;
        }
    }
}
