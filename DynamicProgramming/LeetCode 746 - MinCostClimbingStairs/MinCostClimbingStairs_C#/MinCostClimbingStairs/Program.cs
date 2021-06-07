//应用动态编程思想。因为每次跳的长度可以为1或者2，所以在从每个台阶开始起跳所需的花销应该为：该点的花销加上之前第一个点或者之前第二个点的花销。
//创建一个数组dpMinCost代表从每个点开始跳所需要的最小花销，长度为cost数组的长度。
//将dpMinCost第一和第二个元素设为cost中第一和第二个元素。
//从第三个元素开始遍历数组，当前点开始跳所需的最小花销应该为：当前点花销加上其之前第一个点的最小花销，和当前点花销加上其之前第二个点的最小花销，这两个值之间较小的值。
//因为每次跳的长度可以为1或者2，所以最后返回倒数第一个元素和倒数第二个元素中较小的值。
using System;

namespace MinCostClimbingStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cost = { 1, 2, 21, 45, 2, 4, 1, 8, 3, 1, 8, 23, 8, 31, 2, 3, 7 };
            Console.WriteLine(MinCostClimbingStairs(cost));
        }
        static int MinCostClimbingStairs(int[] cost)
        {
            int[] dpMinCost = new int[cost.Length];
            dpMinCost[0] = cost[0];
            dpMinCost[1] = cost[1];
            for (int i = 2; i < dpMinCost.Length; i++)
            {
                dpMinCost[i] = Math.Min((cost[i] + dpMinCost[i - 2]), (cost[i] + dpMinCost[i - 1]));
            }
            return Math.Min(dpMinCost[dpMinCost.Length - 1], dpMinCost[dpMinCost.Length - 2]);
        }
    }
}
