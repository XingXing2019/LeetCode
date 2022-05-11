using System;

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

            int[] nums =
            {
                41, 37, 24, 1, 0, 2, 4, 3, 9, 7, 6, 5, 8, 11, 10, 16, 15, 12, 13, 14, 19, 18, 17, 20, 22, 21, 23, 35,
                30, 29, 26, 25, 27, 28, 32, 31, 34, 33, 36, 39, 38, 40, 44, 42, 43, 48, 46, 45, 47, 49
            };
            var node = codec.Build(nums);
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
            var preOrder = node.val + "*";
            preOrder += PreOrder(node.left);
            preOrder += PreOrder(node.right);
            return preOrder;
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if(data.Length == 2) return new TreeNode(int.Parse(data.Substring(0, 1)));
            var nodes = data.Split("*", StringSplitOptions.RemoveEmptyEntries);
            var preOrder = new int[nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
                preOrder[i] = int.Parse(nodes[i]);
            return Build(preOrder);
        }

        public TreeNode Build(int[] preOrder)
        {
            if (preOrder.Length == 0) return null;
            int index = -1;
            for (int i = 0; i < preOrder.Length; i++)
            {
                if (preOrder[i] > preOrder[0])
                {
                    index = i;
                    break;
                }
            }
            var left = index == -1 ? preOrder[1..] : preOrder[1..index];
            var right = index == -1 ? new int[0] : preOrder[index..];
            return new TreeNode(preOrder[0]) {left = Build(left), right = Build(right)};
        }
    }
}
