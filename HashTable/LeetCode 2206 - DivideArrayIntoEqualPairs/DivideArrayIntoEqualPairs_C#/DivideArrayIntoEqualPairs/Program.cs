using System;
using System.Linq;

namespace DivideArrayIntoEqualPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool DivideArray(int[] nums)
        {
            return nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()).All(x => x.Value % 2 == 0);
        }
    }
}
