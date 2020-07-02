using System;
using System.Linq;
using System.Net.Mail;

namespace SerializeAndDeserializeBST
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TreeNode(0);
            var b = new TreeNode(1);
            var c = new TreeNode(3);
            //a.left = b;
            //a.right = c;
            var codec = new Codec();
            var data = codec.serialize(a);
            var node = codec.deserialize(data);
        }
    }

    public class Codec
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            return PreOrder(root);
        }

        public string PreOrder(TreeNode node)
        {
            if (node == null) return "";
            var preOrder = node.val + "-";
            preOrder += PreOrder(node.left);
            preOrder += PreOrder(node.right);
            return preOrder;
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            var nodes = data.Split("-", StringSplitOptions.RemoveEmptyEntries);
            var preOrder = new int[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
                preOrder[i] = int.Parse(nodes[i]);
            return Build(preOrder);
        }

        public TreeNode Build(int[] preOrder)
        {
            if (preOrder.Length == 0) return null;
            int firstLarger = preOrder.FirstOrDefault(x => x > preOrder[0]);
            int index = Array.IndexOf(preOrder, firstLarger);
            var left = index == -1 ? preOrder[1..] : preOrder[1..index];
            var right = index == -1 ? new int[0] : preOrder[index..];
            return new TreeNode(preOrder[0]) {left = Build(left), right = Build(right)};
        }
    }
}
