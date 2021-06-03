//创建一个字典记录在当前位置(包括当前位置)之前1比0多几个，和拥有这个差值最靠前的位置。将0和-1存储如字典。代表在数组之前1和0差值为0.
//遍历数组，并用countOne和countZero记录1和0的个数。如果countOne和countZero的差值不在字典中，则将差值和当前位置存入字典。
//否则计算当前位置和这个差值对应位置的距离。并更新res。
using System;
using System.Collections.Generic;

namespace ContiguousArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 1};
            Console.WriteLine(FindMaxLength(nums));
        }
        static int FindMaxLength(int[] nums)
        {
            int res = 0;
            if (nums.Length < 2)
                return res;
            var record = new Dictionary<int, int>();
            record[0] = -1;
            int countZero = 0;
            int countOne = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    countZero++;
                else
                    countOne++;
                if (!record.ContainsKey(countOne - countZero))
                    record[countOne - countZero] = i;
                else
                    res = Math.Max(res, i - record[countOne - countZero]);
            }
            return res;
        }
    }
}
