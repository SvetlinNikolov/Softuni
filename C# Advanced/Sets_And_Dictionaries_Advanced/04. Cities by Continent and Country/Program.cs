

namespace _04._Cities_by_Continent_and_Country
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < inputCount; i++)
            {
                string[] continentCountryCity = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = continentCountryCity[0];
                string country = continentCountryCity[1];
                string city = continentCountryCity[2];

                if (!dict.ContainsKey(continent))
                {
                    dict[continent] = new Dictionary<string, List<string>>();
                    dict[continent].Add(country, new List<string>());
                    dict[continent][country].Add(city);
                }
                else if (dict.ContainsKey(continent))
                {
                    if (!dict[continent].ContainsKey(country))
                    {
                        dict[continent].Add(country, new List<string>());
                        dict[continent][country].Add(city);
                    }
                    else if (dict[continent].ContainsKey(country))
                    {
                        dict[continent][country].Add(city);
                    }
                }
            }
            foreach (var kvp in dict)
            {
                string currentContinent = kvp.Key;
                Console.WriteLine(currentContinent + ":");

                foreach (var countryAndCity in kvp.Value)
                {
                    Console.WriteLine($"{countryAndCity.Key} -> {string.Join(", ", countryAndCity.Value)}");
                }
            }
        }
    }
}
