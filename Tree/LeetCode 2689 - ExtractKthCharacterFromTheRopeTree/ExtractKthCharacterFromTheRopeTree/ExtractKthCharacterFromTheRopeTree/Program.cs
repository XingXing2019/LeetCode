using System;

namespace ExtractKthCharacterFromTheRopeTree
{
    public class RopeTreeNode
    {
        public int len;
        public string val;
        public RopeTreeNode left;
        public RopeTreeNode right;
        public RopeTreeNode(int len = 0, string val = "", RopeTreeNode left = null, RopeTreeNode right = null)
        {
            this.len = len;
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public char GetKthCharacter(RopeTreeNode root, int k)
        {
            var str = DFS(root);
            return str[k - 1];
        }

        public string DFS(RopeTreeNode node)
        {
            if (node == null)
                return string.Empty;
            if (node.left == node.right)
                return node.val;
            return DFS(node.left) + DFS(node.right);
        }
    }
}
