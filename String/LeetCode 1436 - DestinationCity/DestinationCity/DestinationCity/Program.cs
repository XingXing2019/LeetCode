using System;
using System.Collections.Generic;

namespace DestinationCity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string DestCity(IList<IList<string>> paths)
        {
            var allCities = new HashSet<string>();
            var startCities = new HashSet<string>();
            foreach (var path in paths)
            {
                if (!allCities.Contains(path[0]))
                    allCities.Add(path[0]);
                if (!allCities.Contains(path[1]))
                    allCities.Add(path[1]);
                if (!startCities.Contains(path[0]))
                    startCities.Add(path[0]);
            }
            foreach (var city in allCities)
                if (!startCities.Contains(city))
                    return city;
            return "";
        }
    }
}
