using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {

            var registeredCompanyId = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] companies = Console.ReadLine().Split(" -> ").ToArray();

                if (companies[0] == "End")
                {
                    break;
                }

                string company = companies[0];
                string employeeId = companies[1];

                // doesnt contain key, it gets added with value
                if (!registeredCompanyId.ContainsKey(company))
                {
                    registeredCompanyId.Add(company, new List<string>());
                    registeredCompanyId[company].Add(employeeId);
                }
                // contains key, checks if key-value exists 
                else if (registeredCompanyId.ContainsKey(company))
                {
                    if (!registeredCompanyId[company].Contains(employeeId))
                    {
                        registeredCompanyId[company].Add(employeeId);
                    }
                }
            }
            foreach (var company in registeredCompanyId.OrderBy(i => i.Key))
            {
                Console.WriteLine($"{company.Key}");
                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }

        }
    }
}
