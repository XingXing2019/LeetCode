using System;
using System.Linq;

namespace NumberOfSeniorCitizens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountSeniors(string[] details)
        {
            return details.Count(x => GetAge(x) > 60);
        }

        public int GetAge(string detail)
        {
            return int.Parse(detail.Substring(11, 2));
        }
    }
}
