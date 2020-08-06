//创建长度比nums长一位的数组record，用于记录数字的个数。遍历nums，将当前数字在record的记录加一。
//遍历record，将记录为2的数字加入res。
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindAllDuplicatesInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {4, 3, 2, 7, 8, 2, 3, 1};
            Console.WriteLine(FindDuplicates_NoExtraSpace(nums));
        }
        static IList<int> FindDuplicates(int[] nums)
        {
            List<int> res = new List<int>();
            int[] record = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
                record[nums[i]]++;
            for (int i = 0; i < record.Length; i++)
                if (record[i] == 2)
                    res.Add(i);
            return res;
        }
        static IList<int> FindDuplicates_NoExtraSpace(int[] nums)
        {
            var res = new HashSet<int>();
            int index = 0;
            while (index < nums.Length)
            {
                int num = nums[index];
                if (num != index + 1)
                {
                    if (num == nums[num - 1])
                    {
                        res.Add(num);
                        index++;
                    }
                    else
                    {
                        nums[index] = nums[num - 1];
                        nums[num - 1] = num;
                    }
                }
                else
                    index++;
            }
            return res.ToList();
        }
    }
}
