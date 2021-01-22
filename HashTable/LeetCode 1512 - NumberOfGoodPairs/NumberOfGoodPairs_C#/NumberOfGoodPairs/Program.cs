using System;

namespace NumberOfGoodPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int NumIdenticalPairs_Array(int[] nums)
        {
            var frequencies = new int[101];
            var res = 0;
            foreach (var num in nums)
            {
                res += frequencies[num];
                frequencies[num]++;
            }
            return res;
        }
    }
}
