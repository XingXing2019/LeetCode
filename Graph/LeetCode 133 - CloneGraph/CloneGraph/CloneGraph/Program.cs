using System;
using System.Collections.Generic;

namespace CloneGraph
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }
        static Node CloneGraph(Node node)
        {
            if (node == null) return null;
            var queue = new Queue<Node>();
            var map = new Dictionary<Node, Node>();
            queue.Enqueue(node);
            map[node] = new Node(node.val);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                foreach (var neighbor in cur.neighbors)
                {
                    if (!map.ContainsKey(neighbor))
                    {
                        map[neighbor] = new Node(neighbor.val);
                        queue.Enqueue(neighbor);
                    }
                    map[cur].neighbors.Add(map[neighbor]);
                }
            }
            return map[node];
        }
    }
}
