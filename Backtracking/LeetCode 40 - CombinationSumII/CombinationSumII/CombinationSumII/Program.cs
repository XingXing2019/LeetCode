using System;
using System.Collections.Generic;

namespace CombinationSumII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] candidates = { 2, 5, 2, 1, 2 };
            int target = 5;
            Console.WriteLine(CombinationSum2(candidates, target));
        }
        static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            List<IList<int>> res = new List<IList<int>>();
            List<int> item = new List<int>();
            Generate(0, candidates, res, item, target);
            return res;
        }
        static void Generate(int start, int[] candidates, List<IList<int>> res, List<int> item, int target)
        {
            if (target < 0)
                return;
            else if(target == 0)
                res.Add(new List<int>(item));
            else
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    if (i > start && candidates[i] == candidates[i - 1])
                        continue;
                    item.Add(candidates[i]);
                    Generate(i + 1, candidates, res, item, target - candidates[i]);
                    item.Remove(candidates[i]);
                }
            }            
        }
    }
}
