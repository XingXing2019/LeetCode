using System;
using System.Collections.Generic;

namespace DepthOfBSTGivenInsertionOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] order = { 1, 2, 3, 4, 7, 6, 5, 8, 9 };
            Console.WriteLine(MaxDepthBST(order));
        }

        class Node
        {
            public bool IsLeft;
            public int Depth;
            public Node Parent;
            public int Val;

            public Node(bool isLeft, int depth, Node parent, int val)
            {
                IsLeft = isLeft;
                Depth = depth;
                Parent = parent;
                Val = val;
            }
        }

        public static int MaxDepthBST(int[] order)
        {
            if (order.Length == 1) return 1;
            var dp = new Node[order.Length];
            dp[0] = new Node(false, 1, null, order[0]);
            dp[1] = order[1] < order[0] ? new Node(true, 2, dp[0], order[1]) : new Node(false, 2, dp[0], order[1]);
            for (int i = 2; i < order.Length; i++)
            {
                if (dp[i - 1].IsLeft)
                {
                    if (order[i] < order[i - 1])
                        dp[i] = new Node(true, dp[i - 1].Depth + 1, dp[i - 1], order[i]);
                    else
                    {
                        var parent = dp[i - 1];
                        while (parent.Parent != null && order[i] > parent.Parent.Val && parent.Parent.Val > parent.Val)
                            parent = parent.Parent;
                        dp[i] = new Node(false, parent.Depth + 1, parent, order[i]);
                    }
                }
                else
                {
                    if (order[i] > order[i - 1])
                        dp[i] = new Node(false, dp[i - 1].Depth + 1, dp[i - 1], order[i]);
                    else
                    {
                        var parent = dp[i - 1];
                        while (parent.Parent != null && order[i] < parent.Parent.Val && parent.Parent.Val < parent.Val)
                            parent = parent.Parent;
                        dp[i] = new Node(true, parent.Depth + 1, parent, order[i]);
                    }
                }
            }
            return dp[^1].Depth;
        }
    }
}
