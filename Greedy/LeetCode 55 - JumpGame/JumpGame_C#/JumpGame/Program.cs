//设置一个reach代表数组中能达到最远的index，在i小于数组长度并且小于reach的范围内遍历数组。
//如果发现有能到达更远index的元素，则用其替换reach。
//最后检查reach能否达到或超出数组最末元素。
using System;

namespace JumpGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool CanJump(int[] nums)
        {
            int reach = 0;
            int len = nums.Length;
            for (int i = 0; i < len && i <= reach; i++)
            {
                if (i + nums[i] > reach)
                    reach = i + nums[i];
            }
            return reach >= len - 1;
        }
    }
}
