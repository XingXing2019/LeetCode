using System;
using System.Text;

namespace StepByStepDirections
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

    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new TreeNode(5);
            var b = new TreeNode(1);
            var c = new TreeNode(2);
            var d = new TreeNode(3);
            var e = new TreeNode(6);
            var f = new TreeNode(4);

            a.left = b;
            a.right = c;
            b.left = d;
            c.left = e;
            c.right = f;

            int startVal = 4, destVal = 6;
            Console.WriteLine(GetDirections(a, startVal, destVal));
        }
        public static string GetDirections(TreeNode root, int startValue, int destValue)
        {
            StringBuilder path1 = new StringBuilder(), path2 = new StringBuilder();
            DFS(root, startValue, path1);
            DFS(root, destValue, path2);
            int p1 = path1.Length - 1, p2 = path2.Length - 1, count = 0;
            while (p1 >= 0 && p2 >= 0 && path1[p1] == path2[p2])
            {
                p1--;
                p2--;
                count++;
            }
            var up = new string('U', path1.Length - count);
            var down = "";
            for (int i = path2.Length - 1; i >= count; i--)
                down += path2[i];
            return up + down;
        }

        public static bool DFS(TreeNode node, int target, StringBuilder str)
        {
            if (node.val == target) return true;
            if (node.left != null && DFS(node.left, target, str))
                str.Append('L');
            else if (node.right != null && DFS(node.right, target, str))
                str.Append('R');
            return str.Length > 0;
        }
    }
}