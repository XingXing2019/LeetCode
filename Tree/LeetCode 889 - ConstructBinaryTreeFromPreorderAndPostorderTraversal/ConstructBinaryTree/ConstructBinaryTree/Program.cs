//和LeetCode_105和LeetCode_106思路一样。
//切片规则是以找到一个位置，在此位置在pre和post切片的数组中数字相同。
using System;
using System.Linq;

namespace ConstructBinaryTree
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] pre = {1, 2, 4, 5, 3, 6, 7};
            int[] post = {4, 5, 2, 6, 7, 3, 1};

            Console.WriteLine(ConstructFromPrePost(pre, post));
        }
        static TreeNode ConstructFromPrePost(int[] pre, int[] post)
        {
            if (pre.Length == 0 || post.Length == 0) return null;
            int index = FindIndex(pre[1..], post[..^1]);
            var leftPost = post[..(index + 1)];
            var rightPost = post[(index + 1)..^1];
            var leftPre = pre[1..(index + 2)];
            var rightPre = pre[(index + 2)..];
            var root = new TreeNode(pre[0]);
            root.left = ConstructFromPrePost(leftPre, leftPost);
            root.right = ConstructFromPrePost(rightPre, rightPost);
            return root;
        }

        static int FindIndex(int[] pre, int[] post)
        {
            var record = new int[31];
            for (int i = 0; i < post.Length; i++)
            {
                record[pre[i]]++;
                record[post[i]]--;
                if (record.All(x => x == 0))
                    return i;
            }
            return -1;
        }
    }
}
