using System;

namespace NumberOfGoodPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int NumIdenticalPairs(int[] nums)
        {
            var frequencies = new int[101];
            foreach (var num in nums)
                frequencies[num]++;
            int res = 0;
            foreach (var frequency in frequencies)
            {
                if(frequency < 2) continue;
                res += (frequency - 1) * frequency / 2;
            }
            return res;
        }
    }
}
