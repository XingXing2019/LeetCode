//先将数组排序，然后从第一个数字开始到倒数第二个数字，每隔一个数字遍历，如果发现当前数字不等于其后面一个数字，则返回当前数字，否则遍历结束后返回最后一个数字。
using System;
using System.Collections.Generic;

namespace SingleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 2, 1 };
            Console.WriteLine(SingleNumber1(nums));
        } 
        static int SingleNumber1(int[] nums)
        {
            int res = nums[0];
            for (int i = 1; i < nums.Length; i++)
                res = nums[i] ^ res;
            return res;
        }
        static int SingleNumber2(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i+=2)
                if (nums[i] != nums[i + 1])
                    return nums[i];
            return nums[nums.Length - 1];
        }
        static int SingleNumber3(int[] nums)
        {
            var record = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!record.ContainsKey(nums[i]))
                    record[nums[i]] = 1;
                else
                    record[nums[i]]++;
            }
            int res = 0;
            foreach (var kv in record)
                if (kv.Value == 1)
                    res = kv.Key;
            return res;
        }
    }
}
