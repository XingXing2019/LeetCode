using System;
using System.Linq;

namespace MinimumElementsToAdd
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        public int MinElements(int[] nums, int limit, int goal)
        {
            decimal sum = 0;
            foreach (var num in nums) sum += num;
            return (int) Math.Ceiling((Math.Abs(sum - goal)) / limit);
        }
    }
}
