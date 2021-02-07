using System;
using System.Linq;

namespace SumOfUniqueElements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int SumOfUnique(int[] nums)
        {
            return nums.GroupBy(x => x).Where(x => x.Count() == 1).Sum(x => x.Key);
        }
    }
}
