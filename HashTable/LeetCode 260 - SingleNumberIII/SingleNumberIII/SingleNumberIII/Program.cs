//创建字典record记录数字，遍历nums，将不在record中的数字加入record，将已经存在的数字删除。那么遍历结束后字典中就只有两个数。
//将这两个数村塾结果并返回。
using System;
using System.Collections.Generic;
using System.Linq;

namespace SingleNumberIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 1, 3, 2, 5 };
            Console.WriteLine(SingleNumber(nums));
        }
        static int[] SingleNumber(int[] nums)
        {
            var record = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                if (!record.ContainsKey(n))
                    record[n] = 1;
                else
                    record.Remove(n);
            }
            var res = record.Select(i => i.Key).ToArray();
            return res;
        }
    }
}
