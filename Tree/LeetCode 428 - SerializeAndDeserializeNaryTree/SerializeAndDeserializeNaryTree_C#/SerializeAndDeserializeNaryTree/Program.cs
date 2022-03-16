using System;
using System.Collections.Generic;
using System.Text;

namespace SerializeAndDeserializeNaryTree
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
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new Node(1);
            var b = new Node(2);
            var c = new Node(3);
            var d = new Node(4);
            var e = new Node(5);
            var f = new Node(6);

            a.children = new List<Node> { c, b, d };
            c.children = new List<Node> { e, f };

            var obj = new Codec();
            var data = obj.serialize(a);
            var node = obj.deserialize(data);
        }
    }

    public class Codec
    {
        public string serialize(Node root)
        {
            if (root == null) return "";
            var res = root.val;
            var children = "";
            if (root.children == null) return $"{res}[]";
            foreach (var child in root.children)
                children += serialize(child);
            return $"{res}[{children}]";
        }
        
        public Node deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            var index = data.IndexOf('[');
            var root = new Node(int.Parse(data.Substring(0, index)), new List<Node>());
            var children = GetChildren(data.Substring(index + 1, data.Length - index - 2));
            foreach (var child in children)
                root.children.Add(deserialize(child));
            return root;
        }
        
        private List<string> GetChildren(string data)
        {
            var res = new List<string>();
            var child = new StringBuilder();
            var count = 0;
            var seen = false;
            foreach (var l in data)
            {
                if (l == ']')
                    count--;
                else if (l == '[')
                {
                    count++;
                    seen = true;
                }
                child.Append(l);
                if (!seen || count != 0) continue;
                res.Add(child.ToString());
                child = new StringBuilder();
                seen = false;
            }
            return res;
        }
    }
}
