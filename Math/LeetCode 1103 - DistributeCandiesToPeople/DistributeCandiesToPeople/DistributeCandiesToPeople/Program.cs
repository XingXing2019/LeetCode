//创建stepCandy记录每一步要分的糖。在candies大于0的条件下循环。
//每次将candies和step+1中较小的值分给index为stepCandy% num_people的人。接着让stepCandy加一，并令candies减去stepCandies。
using System;

namespace DistributeCandiesToPeople
{
    class Program
    {
        static void Main(string[] args)
        {
            int candies = 60;
            int num_people = 4;
            Console.WriteLine(DistributeCandies(candies, num_people));
        }
        static int[] DistributeCandies(int candies, int num_people)
        {
            int[] res = new int[num_people];
            int stepCandy = 0;
            while (candies > 0)
            {
                res[stepCandy % num_people] += Math.Min(candies, stepCandy + 1);
                stepCandy++;
                candies -= stepCandy;
            }
            return res;
        }
    }
}
