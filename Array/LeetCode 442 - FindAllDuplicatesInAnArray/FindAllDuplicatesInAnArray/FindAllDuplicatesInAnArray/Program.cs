//创建长度比nums长一位的数组record，用于记录数字的个数。遍历nums，将当前数字在record的记录加一。
//遍历record，将记录为2的数字加入res。
using System;
using System.Collections.Generic;

namespace FindAllDuplicatesInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
    }
}
