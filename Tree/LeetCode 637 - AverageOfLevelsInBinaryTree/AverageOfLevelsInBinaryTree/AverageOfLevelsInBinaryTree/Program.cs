using System;
using System.Collections.Generic;

namespace AverageOfLevelsInBinaryTree
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
            var a = new TreeNode(3);
            var b = new TreeNode(9);
            var c = new TreeNode(20);
            var d = new TreeNode(15);
            var e = new TreeNode(7);

            a.left = b;
            a.right = c;
            c.left = d;
            c.right = e;

            Console.WriteLine(AverageOfLevels(a));
        }
        static IList<double> AverageOfLevels(TreeNode root)
        {
            var record = new List<double[]>();
            GenerateList(root, 0, record);
            var res  = new List<double>();
            foreach (var r in record)
                res.Add(r[0] / r[1]);
            return res;
        }

        static void GenerateList(TreeNode node, int level, List<double[]> record)
        {
            if(node == null)
                return;
            if (record.Count <= level)
                record.Add(new double[2]);
            record[level][0] += node.val;
            record[level][1]++;
            GenerateList(node.left, level + 1, record);
            GenerateList(node.right, level + 1, record);
        }
    }
}
