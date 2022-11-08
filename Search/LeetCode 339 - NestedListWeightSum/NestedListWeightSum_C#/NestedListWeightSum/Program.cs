using System;
using System.Collections.Generic;

namespace NestedListWeightSum
{
    interface NestedInteger
    {
        // @return true if this NestedInteger holds a single integer, rather than a nested list.
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
        static int DepthSum_DFS(IList<NestedInteger> nestedList)
        {
            var res = 0;
            foreach (var nestedInteger in nestedList)
            {
                var temp = 0;
                DFS(nestedInteger, 1, ref temp);
                res += temp;
            }
            return res;
        }

        static void DFS(NestedInteger integer, int depth, ref int res)
        {
            if (integer.IsInteger())
            {
                res += integer.GetInteger() * depth;
                return;
            }
            foreach (var nestedInteger in integer.GetList())
                DFS(nestedInteger, depth + 1, ref res);
        }

        static int DepthSum_BFS(IList<NestedInteger> nestedList)
        {
            var queue = new Queue<NestedInteger>();
            foreach (var node in nestedList)
                queue.Enqueue(node);
            int res = 0, depth = 0;
            while (queue.Count != 0)
            {
                var count = queue.Count;
                depth++;
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur.IsInteger())
                        res += depth * cur.GetInteger();
                    else
                    {
                        foreach (var node in cur.GetList())
                            queue.Enqueue(node);
                    }
                }
            }
            return res;
        }
    }
}
