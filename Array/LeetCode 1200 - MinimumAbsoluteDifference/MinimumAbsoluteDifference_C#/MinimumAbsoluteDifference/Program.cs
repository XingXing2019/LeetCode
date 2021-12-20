//先将数组排序，遍历数组找到最小差值。
//创建record字典辅助寻找符合条件的数字对。遍历数组，将当前数字加入字典，并检查字典中是否存在于当前数字差值为最小差值的数字。如果有，则将他们加入res。
using System;
using System.Collections.Generic;

namespace MinimumAbsoluteDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 8, -10, 23, 19, -4, -14, 27 };
            Console.WriteLine(MinimumAbsDifference(arr));
        }
        static IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            IList<IList<int>> res = new List<IList<int>>();
            var record = new Dictionary<int, int>();
            Array.Sort(arr);
            int minDiff = int.MaxValue;
            for (int i = 1; i < arr.Length; i++)
                minDiff = Math.Min(minDiff, arr[i] - arr[i - 1]);
            for (int i = 0; i < arr.Length; i++)
            {
                record[arr[i]] = 1;
                if (record.ContainsKey(arr[i] - minDiff))
                    res.Add(new int[2] { arr[i] - minDiff, arr[i] });
            }
            return res;
        }
    }
}
