using System;
using System.Collections.Generic;

namespace NestedListWeightSumII
{
    interface NestedInteger
    {
        bool IsInteger();

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();

        // Set this NestedInteger to hold a single integer.
        public void SetInteger(int value);

        // Set this NestedInteger to hold a nested list and adds a nested integer to it.
        public void Add(NestedInteger ni);

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int DepthSumInverse(IList<NestedInteger> nestedList)
        {
            int maxHeight = 0, res = 0;
            var record = new List<int[]>();
            foreach (var nestedInteger in nestedList)
                DFS(nestedInteger, 1, record, ref maxHeight);
            foreach (var pair in record)
                res += pair[0] * (maxHeight - pair[1] + 1);
            return res;
        }

        static void DFS(NestedInteger integer, int height, List<int[]> record, ref int maxHeight)
        {
            if (integer.IsInteger())
            {
                maxHeight = Math.Max(maxHeight, height);
                record.Add(new []{integer.GetInteger(), height});
            }
            foreach (var nestedInteger in integer.GetList())
                DFS(nestedInteger, height + 1, record, ref maxHeight);
        }
    }
}
