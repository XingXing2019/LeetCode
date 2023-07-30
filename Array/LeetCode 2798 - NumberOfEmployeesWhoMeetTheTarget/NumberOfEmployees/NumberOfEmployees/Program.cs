using System;
using System.Linq;

namespace NumberOfEmployees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int NumberOfEmployeesWhoMetTarget(int[] hours, int target)
        {
            return hours.Count(x => x >= target);
        }
    }
}
