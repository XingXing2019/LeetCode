using System;
using System.Linq;

namespace MaximumXORAfterOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaximumXOR(int[] nums)
        {
            var res = 0;
            for (int i = 0; i < 32; i++)
            {
                var count = nums.Count(x => ((x >> i) & 1) == 1);
                if (count == 0) continue;
                res += 1 << i;
            }
            return res;
        }
    }
}
