using System;
using System.Collections.Generic;

namespace FlattenBinaryTreeToLinkedList
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
            var a = new TreeNode(1);
            var b = new TreeNode(2);
            var c = new TreeNode(5);
            var d = new TreeNode(3);
            var e = new TreeNode(4);
            var f = new TreeNode(5);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.right = f;

            Flatten(a);
        }
        static void Flatten_InPlace(TreeNode root)
        {
            var point = root;
            while (point != null)
            {
                if (point.left != null)
                {
                    var mostRight = point.left;
                    while (mostRight.right != null)
                        mostRight = mostRight.right;
                    mostRight.right = point.right;
                    point.right = point.left;
                    point.left = null;
                }
                point = point.right;
            }
        }

        public void Flatten_NotInPlace(TreeNode root)
        {
            var record = new List<TreeNode>();
            DFS_NotInPlace(root, record);
            for (int i = 0; i < record.Count - 1; i++)
            {
                record[i].left = null;
                record[i].right = record[i + 1];
            }
        }

        private void DFS_NotInPlace(TreeNode node, List<TreeNode> record)
        {
            if (node == null) return;
            record.Add(node);
            DFS_NotInPlace(node.left, record);
            DFS_NotInPlace(node.right, record);
        }
    }
}
