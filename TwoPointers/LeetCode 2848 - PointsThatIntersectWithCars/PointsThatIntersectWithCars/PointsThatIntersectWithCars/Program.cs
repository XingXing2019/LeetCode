using System;
using System.Collections.Generic;
using System.Linq;

namespace PointsThatIntersectWithCars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int NumberOfPoints(IList<IList<int>> nums)
        {
            nums = nums.OrderBy(x => x[0]).ToList();
            int li = nums[0][0], hi = nums[0][1], res = 0;
            foreach (var num in nums)
            {
                if (hi >= num[0])
                    hi = Math.Max(hi, num[1]);
                else
                {
                    res += hi - li + 1;
                    li = num[0];
                    hi = num[1];
                }
            }
            return res + hi - li + 1;
        }
    }
}
