using System;
using System.Collections.Generic;

namespace CloneBinaryTreeWithRandomPointer
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node random;
        public Node(int val = 0, Node left = null, Node right = null, Node random = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
            this.random = random;
        }
    }

    public class NodeCopy
    {
        public int val;
        public NodeCopy left;
        public NodeCopy right;
        public NodeCopy random;
        public NodeCopy(int val = 0, NodeCopy left = null, NodeCopy right = null, NodeCopy random = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
            this.random = random;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private Dictionary<Node, NodeCopy> dict = new Dictionary<Node, NodeCopy>();
        public NodeCopy CopyRandomBinaryTree(Node root)
        {
            if (root == null) return null;
            var copy = CopyNode(root);
            DFS(root, copy);
            return copy;
        }

        public NodeCopy CopyNode(Node node)
        {
            if (node == null) return null;
            var copy = new NodeCopy(node.val);
            dict[node] = copy;
            copy.left = CopyNode(node.left);
            copy.right = CopyNode(node.right);
            return copy;
        }

        public void DFS(Node node, NodeCopy copy)
        {
            if (node == null) return;
            copy.random = node.random == null ? null : dict[node.random];
            DFS(node.left, copy.left);
            DFS(node.right, copy.right);
        }
    }
}
