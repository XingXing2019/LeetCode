using System;
using System.Collections.Generic;

namespace StampingTheSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string stamp = "abc", target = "bbbbb";
            Console.WriteLine(MovesToStamp(stamp, target));
        }
        public static int[] MovesToStamp(string stamp, string target)
        {
            var res = new List<int>();
            var checkedIndexes = new HashSet<int>();
            var canStamp = true;
            while (canStamp)
            {
                var temp = false;
                for (int i = 0; i <= target.Length - stamp.Length; i++)
                {
                    if (!IsSame(stamp, target, i, checkedIndexes)) continue;
                    temp = true;
                    res.Add(i);
                    for (int j = 0; j < stamp.Length; j++)
                        checkedIndexes.Add(i + j);
                }
                canStamp = temp;
            }
            if (checkedIndexes.Count != target.Length) return new int[0];
            res.Reverse();
            return res.ToArray();
        }

        public static bool IsSame(string stamp, string target, int li, HashSet<int> checkedIndexes)
        {
            int count = 0;
            for (int i = 0; i < stamp.Length; i++)
            {
                if (checkedIndexes.Contains(li + i))
                {
                    count++;
                    continue;
                }
                if (stamp[i] != target[li + i])
                    return false;
            }
            return count < stamp.Length;
        }
    }
}
