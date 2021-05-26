using System;

namespace PartitioningIntoMinimumNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MinPartitions(string n)
        {
            var res = 0;
            foreach (var digit in n)
                res = Math.Max(res, digit - '0');
            return res;
        }
    }
}
