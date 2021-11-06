using System;
using System.Collections.Generic;
using System.Linq;

namespace SingleNumberIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 1, 3, 2, 5 };
            Console.WriteLine(SingleNumber(nums));
        }

        public int[] SingleNumber_BitManipulation(int[] nums)
        {
	        int xOr = 0, num1 = 0;
	        foreach (var num in nums)
		        xOr ^= num;
	        var flag = xOr & -xOr;
	        foreach (var num in nums)
	        {
		        if ((flag & num) != 0)
			        num1 ^= num;
	        }
	        return new[] {num1, xOr ^ num1};
        }

        static int[] SingleNumber(int[] nums)
        {
            var record = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                if (!record.ContainsKey(n))
                    record[n] = 1;
                else
                    record.Remove(n);
            }
            var res = record.Select(i => i.Key).ToArray();
            return res;
        }
    }
}
