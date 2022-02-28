//创建res列表接收结果，创建right代表范围的有边界，初始值设为数组第一个数字。创建left代表范围左边界，初始值设为right。创建tem字符串存储每个范围，初始值设为right。
//从第二个数字开始遍历。如果发现数字连续，则使right加一。否则，当左右边界不一样时，使tem加上箭头和right。将tem加入res，并重新将left和right设为当前数字，并将tem设为right。
//遍历结束后需要将最后一次的tem加入res，仍需判断left和right是否一致。
using System;
using System.Collections.Generic;

namespace SummaryRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2 };
            Console.WriteLine(SummaryRanges(nums));
        }
        static IList<string> SummaryRanges(int[] nums)
        {
            List<string> res = new List<string>();
            if (nums.Length == 0)
                return res;
            int right = nums[0];
            int left = right;
            string tem = right.ToString();
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == right + 1)
                    right++;
                else
                {
                    if (right != left)
                        tem += "->" + right;
                    res.Add(tem);
                    right = nums[i];
                    left = right;
                    tem = right.ToString();
                }
            }
            if (right != left)
                tem += "->" + right;
            res.Add(tem);
            return res;
        }
    }
}
