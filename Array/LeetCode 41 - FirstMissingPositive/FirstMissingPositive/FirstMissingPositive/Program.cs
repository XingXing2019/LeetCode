//试图将nums[i]调换到nums[i]-1的位置上去。需要使用while循环，最后返回第一个不满足nums[i]等于i+1的数字。
//如果所有数字都满足，证明在nums中包含了所有应有的正数，则返回nums的长度加一。
using System;

namespace FirstMissingPositive
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {-1, 4, 2, 1, 9, 10};
            Console.WriteLine(FirstMissingPositive(nums));
        }
        static int FirstMissingPositive(int[] nums)
        {
            if (nums.Length == 0)
                return 1;
            for (int i = 0; i < nums.Length; i++)
            {
                while(nums[i] > 0 && nums[i] < nums.Length && nums[i] != nums[nums[i] - 1])
                {
                    int tem = nums[i];
                    nums[i] = nums[tem - 1];
                    nums[tem - 1] = tem;
                }              
            }
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] != i + 1)
                {
                    res = i + 1;
                    break;
                }                    
            }
            if (res == 0)
                res = nums.Length + 1;
            return res;
        }
    }
}
