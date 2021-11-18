//因为数组中的数字在数组长度和1之间，则可将其看为一个索引。
//遍历数组，将每个数字看做索引，并对其对应的位置取负。如果数组缺失数字，则该数字作为索引，在数组中对应的位置一定没有被取负。
//再次遍历数组，将非负的数字加一存入结果。
using System;
using System.Collections.Generic;

namespace FindAllNumbersDisappearedInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 3, 2, 7, 8, 2, 3, 1 };
            Console.WriteLine(FindDisappearedNumbers(nums));
        }
        static IList<int> FindDisappearedNumbers(int[] nums)
        {
            foreach (var num in nums)
            {
                int index = Math.Abs(num) - 1;
                if (nums[index] > 0)
                    nums[index] *= -1;
            }
            var res = new List<int>();
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] > 0)
                    res.Add(i + 1);
            return res;
        }
    }
}
