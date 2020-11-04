//创建map字典记录每个数字出现的次数。创建res接收结果。
//遍历数组，如果当前数字不在map字典中，则将当前数字与1加入map。否则使map中的当前数字计数加一。
//如果当前数字在map中的计数超过nums长度的1/2，则将res设为当前数字，并终止遍历。
//最后返回res。
using System;
using System.Collections.Generic;

namespace MajorityElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MajorityElement_HashMap(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                    dict[num] = 0;
                dict[num]++;
                if (dict[num] > nums.Length / 2)
                    return num;
            }
            return -1;
        }
        public int MajorityElement_Sort(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }
    }
}
