using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Population_Counter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary <string, long> countryAndPopulation = new Dictionary<string, long>();
            Dictionary <string, List<string>> countryAndCities = new Dictionary<string, List<string>>();

            while ((command = Console.ReadLine()) != "report")
            {
                string[] countryInfo = command
                    .Split('|');

                string country = countryInfo[1];
                string city = countryInfo[0];
                string population = countryInfo[2];

                string cityPopulation = $"{city}:{population}";

                if (!countryAndCities.ContainsKey(country))
                {
                    countryAndCities[country] = new List<string>();
                    countryAndPopulation.Add(country, 0);
                }
 
                countryAndCities[country].Add(cityPopulation);
                countryAndPopulation[country] += long.Parse(population);               
            }

            foreach (var countryPopulation in countryAndPopulation.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{countryPopulation.Key} (total population: {countryPopulation.Value})");

                Dictionary<string, long> cityPopulation = new Dictionary<string, long>();

                foreach (var countryCity in countryAndCities)
                {     
                    if (countryPopulation.Key == countryCity.Key)
                    {
                        foreach (var city in countryCity.Value)
                        {
                            {
                                string cityName = city.Split(':')[0];
                                long population = long.Parse(city.Split(':')[1]);
                                cityPopulation.Add(cityName, population);
                            }
                        }                      
                    }                                                                         
                }

                cityPopulation = cityPopulation
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(c => c.Key, x => x.Value);

                foreach (var city in cityPopulation)
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
