//一定是用第一个数字除以之后的所有数字放在一起得到的结果最大。相当于第二个数字做分母，其余所有数字乘积最分子。
using System;
using System.Text;

namespace OptimalDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1000, 100, 10, 2};
            Console.WriteLine(OptimalDivision(nums));
        }
        static string OptimalDivision(int[] nums)
        {
            if (nums.Length == 1) return nums[0].ToString();
            var res = new StringBuilder();
            res.Append(nums[0]);
            for (int i = 1; i < nums.Length; i++)
                res.Append("/" + nums[i]);
            if (nums.Length <= 2) return res.ToString();
            int index = nums[0].ToString().Length + 1;
            res.Insert(index, "(");
            res.Append(")");
            return res.ToString();
        }
    }
}
