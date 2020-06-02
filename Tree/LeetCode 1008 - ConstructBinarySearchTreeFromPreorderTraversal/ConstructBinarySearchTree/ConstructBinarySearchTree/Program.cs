//前序遍历第一个数就是根节点，找到第一个比根节点大的位置，前面的就是左子树，那个位置和他后面的就是右子树。递归带进去分别生成左右子树就做出来了
using System;
using System.Linq;

namespace ConstructBinarySearchTree
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
            int[] preorder = {4, 2};
            Console.WriteLine(BstFromPreorder(preorder));
        }
        static TreeNode BstFromPreorder(int[] preorder)
        {
            if (preorder.Length == 0) return null;
            int firstLarger = preorder.FirstOrDefault(x => x > preorder[0]);
            int index = Array.IndexOf(preorder, firstLarger);
            var root = new TreeNode(preorder[0]);
            int[] left = index == -1 ? preorder[1..] : preorder[1..index];
            int[] right = index == -1 ? new int[0] : preorder[index..];
            root.left = BstFromPreorder(left);
            root.right = BstFromPreorder(right);
            return root;
        }
    }
}
