using System;
using System.Linq;

namespace SpecialArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {4, 5};
            Console.WriteLine(SpecialArray_N(nums));
        }
        static int SpecialArray_NlogN(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i <= nums.Length; i++)
            {
                int li = 0, hi = nums.Length - 1;
                while (li < hi)
                {
                    int mid = li + (hi - li) / 2;
                    if (nums[mid] >= i)
                        hi = mid;
                    else
                        li = mid + 1;
                }
                if (nums[li] < i) li++;
                if (nums.Length - li == i)
                    return i;
            }
            return -1;
        }
        static int SpecialArray_N(int[] nums)
        {
            int max = nums.Max();
            var record = new int[max + 1];
            foreach (var num in nums)
                record[num]++;
            var count = 0;
            for (int i = record.Length - 1; i >= 0; i--)
            {
                count += record[i];
                if (count == i)
                    return i;
            }
            return -1;
        }
    }
}
