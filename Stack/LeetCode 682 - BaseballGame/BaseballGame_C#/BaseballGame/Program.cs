//用一个列表实现栈，然后按要求将数字存入列表，在计算列表中数字和。
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseballGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ops = { "5", "-2", "4", "C", "D", "9", "+", "+" };
            Console.WriteLine(CalPoints(ops));
        }
        static int CalPoints(string[] ops)
        {
            var nums = new List<int>();
            foreach (var op in ops)
            {
                if (int.TryParse(op, out var num))
                    nums.Add(num);
                else if (op == "+")
                    nums.Add(nums[^1] + nums[^2]);
                else if (op == "C")
                    nums.RemoveAt(nums.Count - 1);
                else
                    nums.Add(nums[^1] * 2);
            }
            return nums.Sum();
        }
    }
}
