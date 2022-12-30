using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputInfo = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continentAndCountryCities = 
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < numberOfInputInfo; i++)
            {
                string[] continentInfo = Console.ReadLine()
                    .Split(' ');

                string continent = continentInfo[0];
                string country = continentInfo[1];
                string city = continentInfo[2];

                if (!(continentAndCountryCities.ContainsKey(continent)))
                {
                    Dictionary<string, List<string>> countryAndCities = new Dictionary<string, List<string>>();

                    countryAndCities[country] = new List<string>() { city };
                    continentAndCountryCities[continent] = countryAndCities;
                }
                else
                {
                    if (!(continentAndCountryCities[continent].ContainsKey(country)))
                    {
                        continentAndCountryCities[continent][country] = new List<string>() { city };
                    }
                    else
                    {
                        continentAndCountryCities[continent][country].Add(city);
                    }
                }
            }

            foreach (var continent in continentAndCountryCities)
            {
                Console.WriteLine($"{continent.Key}:");
                
                foreach (KeyValuePair<string, List<string>> countryCities in continent.Value)
                {
                    List<string> cities = new List<string>();
                    cities = countryCities.Value;

                    Console.Write($"   {countryCities.Key} -> ");
                    Console.WriteLine(string.Join(", ", cities));
                }
            }
        }
    }
}
