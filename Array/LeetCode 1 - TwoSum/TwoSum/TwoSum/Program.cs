//解法一为暴力算法检查每两个元素的和。时间复杂度为O(n^2)。
//解法二为使用哈希映射记录当前数字和其在数组中的位置，则只需遍历一次数组。时间复杂度为O(n)。
//创建res数组接收结果。创建key和value为int的字典hashMap用来存储数字和位置的映射。
//遍历nums数组，如果字典中存在target减去当前数字，证明能和当前数字组成target的数字已经在之前遍历过。
//则将该数字在hashMap对应的value(该数字的位置)和当前i(当前数字的位置)存入res，并停止遍历。
//否则判断hashMap是否已经存在当前数字的key，如果没有，则将当前数字和其位置存入hashMap。
using System;
using System.Collections.Generic;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 2, 2, 4 };
            int target = 6;
            Console.WriteLine(TwoSum(nums, target));
        }
        static int[] TwoSum(int[] nums, int target)
        {
            int[] res = new int[2];
            Dictionary<int, int> hashMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (hashMap.ContainsKey(target - nums[i]))
                {
                    res[0] = i;
                    res[1] = hashMap[target - nums[i]];
                    break;
                }
                else
                    if(!hashMap.ContainsKey(nums[i]))
                        hashMap.Add(nums[i], i);
            }
            return res;
        }
        public int[] TwoSum2(int[] nums, int target)
        {
            int[] res = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[2] { i, j };
                    }
                }
            }
            return res;
        }
    }
}
