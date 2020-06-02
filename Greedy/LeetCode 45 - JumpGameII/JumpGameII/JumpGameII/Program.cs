//解题思路为试图在当前点和当前能到达最远点之间，找到一个能到达更远的点，在跳跃。这样能保证用最少的次数调到终点。
//设立JumpTimes代表跳跃次数。reach代表能到达最远的点位，初始值设为数组第一个元素。cur代表当前点，tem用于辅助找到跳跃点。
//在reach没有到达数组尽头时循环，遍历当前点和最远到达点之间的元素，找到能到达最远点的位置，用tem记录该点位。
//将cur跳跃到该点位，并使jumpTime加一。
//当reach到达或超过数组尽头时停止循环，这时cur还需在跳跃一次，所以返回jumpTime + 1。
using System;

namespace JumpGameII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 4, 2, 0, 1, 1, 0 };
            Console.WriteLine(Jump(nums));
        }
        static int Jump(int[] nums)
        {
            if (nums.Length <= 1)
                return 0;
            int jumpTimes = 0;
            int reach = nums[0];
            int cur = 0;
            int tem = 0;
            while (reach < nums.Length - 1)
            {
                for (int i = cur; i < nums.Length && i <= cur + nums[cur]; i++)
                {
                    if (i + nums[i] > reach)
                    {
                        reach = i + nums[i];
                        tem = i;
                    }
                }
                cur = tem;
                jumpTimes++;
            }
            return jumpTimes + 1;
        }
    }
}
