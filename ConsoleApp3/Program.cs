using System;
using System.Collections.Generic;

namespace CityEnumExample
{
    class Program
    {
        enum Country
        {
            Ukraine,
            Spain,
            Italy
        }

        enum City
        {
            // Ukraine
            Kyiv = 1,
            Lviv,
            Odessa,
            // Spain
            Madrid,
            Barcelona,
            Valencia,
            // Italy
            Rome,
            Milan
        }

        static void Main(string[] args)
        {
            Dictionary<Country, List<City>> countryCities = new Dictionary<Country, List<City>>
            {
                { Country.Ukraine, new List<City> { City.Kyiv, City.Lviv, City.Odessa } },
                { Country.Spain, new List<City> { City.Madrid, City.Barcelona, City.Valencia } },
                { Country.Italy, new List<City> { City.Rome, City.Milan } }
            };

            Console.WriteLine("Список міст:");
            foreach (City city in Enum.GetValues(typeof(City)))
            {
                Console.WriteLine($"{(int)city} - {city}");
            }

            Console.WriteLine("\nВведіть номери міст, які ви хочете відвідати (відокремлюйте номери комами):");
            string input = Console.ReadLine();
            string[] inputNumbers = input.Split(',');

            List<City> selectedCities = new List<City>();
            foreach (string number in inputNumbers)
            {
                if (int.TryParse(number.Trim(), out int cityNumber) && Enum.IsDefined(typeof(City), cityNumber))
                {
                    selectedCities.Add((City)cityNumber);
                }
            }

            Console.WriteLine("\nВи обрали відвідати наступні міста:");
            foreach (City city in selectedCities)
            {
                Console.WriteLine($"{city} ({GetCountryByCity(city)})");
            }



            Console.WriteLine("\nПерелік міст окремо по кожній країні:");
            foreach (var country in countryCities)
            {
                Console.WriteLine($"\n{country.Key}:");
                foreach (var city in country.Value)
                {
                    Console.WriteLine(city);
                }
            }
        }

        static Country GetCountryByCity(City city)
        {
            switch (city)
            {
                case City.Kyiv:
                case City.Lviv:
                case City.Odessa:
                    return Country.Ukraine;
                case City.Madrid:
                case City.Barcelona:
                case City.Valencia:
                    return Country.Spain;
                case City.Rome:
                case City.Milan:
                    return Country.Italy;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
