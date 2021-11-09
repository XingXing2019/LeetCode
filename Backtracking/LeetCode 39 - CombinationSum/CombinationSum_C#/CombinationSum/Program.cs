using System;
using System.Collections.Generic;

namespace CombinationSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] candidates = { 2, 3, 6, 7 };
            int target = 7;
            Console.WriteLine(CombinationSum(candidates, target));
        }
        static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            int index = 0;
            List<int> list = new List<int>();
            List<IList<int>> res = new List<IList<int>>();
            Generate(index, candidates, target, list, res);
            return res;
        }
        static void Generate(int index, int[] candidates, int target, List<int> list, List<IList<int>> res)
        {
            if (target == 0)
                res.Add(new List<int>(list));
            for (int i = index; i < candidates.Length && target >= candidates[i]; i++)
            {
                list.Add(candidates[i]);
                Generate(i, candidates, target - candidates[i], list, res);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
