//本题需要原地修改现有数组，将不重复的数放到数组前列，最后数组中不重复元素的个数。
//设置指针pos，使其指向数组第二个元素，因为第一个元素不论怎样都会被保留。
//从数组第二个元素开始遍历数组，如果当前元素比前一元素大，则将pos所指元素更新为现在遍历到的元素。
//将pos指针加一，移向下一元素。
//最后返回pos即可。
using System;

namespace RemoveDuplicatesFromSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { };
            Console.WriteLine(RemoveDuplicates(nums));
        }
        static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int pos = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                    nums[pos++] = nums[i];
            }
            return pos;
        }
    }
}
