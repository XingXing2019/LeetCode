using System;
using System.Collections.Generic;

namespace NaryTreeLevelOrderTraversal
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public IList<IList<int>> LevelOrder(Node root)
        {
            var res = new List<IList<int>>();
            if (root == null) return res;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var temp = new List<int>();
                var count = queue.Count;
                while (count != 0)
                {
                    var current = queue.Dequeue();
                    temp.Add(current.val);
                    foreach (var child in current.children)
                        queue.Enqueue(child);
                    count--;
                }
                res.Add(temp);
            }
            return res;
        }
    }
}
