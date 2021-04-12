using System;
using System.Linq;

namespace LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 30, 34, 5, 9 };
            Console.WriteLine(LargestNumber_Sort2(nums));
        }
        static string LargestNumber(int[] nums)
        {
            if (nums.All(n => n == 0))
                return "0";
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (CheckGreater(nums[i], nums[j]))
                    {
                        int tem = nums[i];
                        nums[i] = nums[j];
                        nums[j] = tem;
                    }
                }
            }
            string res = "";
            for (int i = nums.Length - 1; i >= 0; i--)
                res += nums[i].ToString();
            return res;
        }
        static bool CheckGreater(int a, int b)
        {
            string A = a.ToString();
            string B = b.ToString();
            return double.Parse(A + B) > double.Parse(B + A);
        }

        static string LargestNumber_Sort(int[] nums)
        {
            if (nums.All(n => n == 0)) return "0";
            var res = new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                res[i] = nums[i].ToString();
            Array.Sort(res, (a, b) => (int) (double.Parse(b + a) - double.Parse(a + b)));
            return string.Join("", res);
        }
    }
}
