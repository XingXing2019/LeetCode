//创建point指针用于辅助原地修改数组，将其初始值设为0。
//用i指针遍历nums数组，如果发现与val不相等的元素，则将point所指向的元素设为该元素，并使point加一向前前进一位。
//最后返回point。
using System;

namespace RemoveElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int RemoveElement(int[] nums, int val)
        {
            int point = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] != val)
                {
                    nums[point] = nums[i];
                    point++;
                }
            }
            return point;
        }
    }
}
