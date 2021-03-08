//先正向遍历将nums中元素的前缀乘积记入res，再逆向遍历将nums中元素的后缀乘积乘入res。
using System;

namespace ProductOfArrayExceptSelf
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 2, 3, 4};
            Console.WriteLine(ProductExceptSelf(nums));
        }
        static int[] ProductExceptSelf(int[] nums)
        {
            int[] res = new int[nums.Length];
            res[0] = 1;
            for (int i = 1; i < nums.Length; i++)
                res[i] = res[i - 1] * nums[i - 1];
            int suffix = 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                suffix *= nums[i + 1];
                res[i] *= suffix;
            }
            return res;
        }

        public int[] ProductExceptSelf2(int[] nums)
        {
            int[] res = new int[nums.Length];
            int product = 1;
            int numOfZero = 0;
            int pos = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                    product *= nums[i];
                else
                {
                    numOfZero++;
                    pos = i;
                }
                if (numOfZero > 1)
                    break;
            }
            if (numOfZero == 0)
            {
                for (int i = 0; i < res.Length; i++)
                    res[i] = product / nums[i];
            }
            else if(numOfZero == 1)
                res[pos] = product;
            return res;
        }
    }
}
