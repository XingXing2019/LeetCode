//创建Swap方法用于对调数组中的两个数，参数为数组和两个需要对调数字的index。
//创建Reverse方法用于翻转数组，参数为数组，和翻转的起点和终点。
//在主方法中现将k对数组的长度取余，以避免越界情况发生。
//将nums.Length - 1 - k点左右两边倒额数组分别翻转。
//再将整个数组翻转。
using System;

namespace RotateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int k = 3;
            Rotate(nums, k);
        }
        static void Rotate(int[] nums, int k)
        {
            k %= nums.Length;
            Reverse(nums, 0, nums.Length - k - 1);
            Reverse(nums, nums.Length - k, nums.Length - 1);
            Reverse(nums, 0, nums.Length - 1);
        }
        static void Swap(int[] nums, int a, int b)
        {
            int tem = nums[a];
            nums[a] = nums[b];
            nums[b] = tem;
           
        }
        static void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
                Swap(nums, start++, end--);
        }


        static void Rotate2(int[] nums, int k)
        {
            k %= nums.Length;
            int hi = nums.Length - k;
            int pointerLi = hi - 1;
            int pointerHi = nums.Length - 1;
            int[] tem = new int[k];
            for (int i = 0; i < tem.Length; i++)
                tem[i] = nums[hi++];
            while (pointerLi >= 0)
                nums[pointerHi--] = nums[pointerLi--];
            for (int i = 0; i < tem.Length; i++)
                nums[i] = tem[i];
        }
    }
}
