using System;

namespace MaximumNumberOfGroups
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        
        public int MaximumGroups(int[] grades)
        {
            return (-1 + (int) Math.Sqrt(1 + 8 * grades.Length)) / 2;
        }
    }
}
