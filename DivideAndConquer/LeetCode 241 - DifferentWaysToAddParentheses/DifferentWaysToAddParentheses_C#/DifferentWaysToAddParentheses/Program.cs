using System;
using System.Collections.Generic;

namespace DifferentWaysToAddParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "25-1-1";
            Console.WriteLine(DiffWaysToCompute(input));
        }
        static IList<int> DiffWaysToCompute(string input)
        {
            return DFS(input, new Dictionary<string, List<int>>()); ;
        }

        static List<int> DFS(string input, Dictionary<string, List<int>> dict)
        {
            if (dict.ContainsKey(input))
                return dict[input];
            var nums = new List<int>();
            if (int.TryParse(input, out var num))
                nums.Add(num);
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i])) continue;
                var left = DFS(input.Substring(0, i), dict);
                var right = DFS(input.Substring(i + 1), dict);
                foreach (var l in left)
                {
                    foreach (var r in right)
                    {
                        nums.Add(input[i] == '+' ? l + r : input[i] == '-' ? l - r : l * r);
                    }
                }
            }
            dict[input] = nums;
            return nums;
        }
    }
}
