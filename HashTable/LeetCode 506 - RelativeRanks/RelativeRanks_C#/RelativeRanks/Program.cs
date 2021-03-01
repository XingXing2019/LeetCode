//先获取nums中的最大值。然后创建一个长度为最大值长度加一的数组record。将每个分数对应的index+1计入record。
//倒着遍历record，将record中分数最高的三个index-1计入奖牌数组。
//然后继续倒着record，将res中对应的index位置设为rank，每次让rank加一。并在res中设置将三个的奖牌的人。
//需特殊处理nums为空，或不足三人的特殊情况。
using System;
using System.Collections.Generic;
using System.Linq;

namespace RelativeRanks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {5, 4};
            Console.WriteLine(FindRelativeRanks(nums));
        }
        static string[] FindRelativeRanks(int[] nums)
        {
            string[] res = new string[nums.Length];
            if (nums.Length == 0)
                return res;
            int max = nums.Max(n => n);
            int[] record = new int[max + 1];
            for (int i = 0; i < nums.Length; i++)
                record[nums[i]] = i + 1;
            int rank = 4, j = record.Length - 1;
            int count = 3;
            List<int> medals = new List<int>();
            for (; medals.Count != 3 && j >= 0; j--)
                if(record[j] != 0)
                   medals.Add(record[j] - 1);
            for (; j >= 0; j--)
            {
                if (record[j] != 0)
                {
                    res[record[j] - 1] = rank.ToString();
                    rank++;
                }
            }
            string[] prize = {"Gold Medal", "Silver Medal", "Bronze Medal"};
            for (int i = 0; i < medals.Count; i++)
                res[medals[i]] = prize[i];
            return res;
        }
    }
}
