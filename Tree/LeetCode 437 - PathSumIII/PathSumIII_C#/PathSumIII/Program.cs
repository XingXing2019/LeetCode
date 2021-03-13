//创建DFS辅助递归遍历，思路为以当前节点作为根节点，向下寻找满足和为sum的路径总数。
//当前节点为空的时候证明已经到树顶，往下没有可以满足条件的路径，则返回0。
//否则递归遍历当前节点一下的左子树和右子树，寻找能满足和为sum减去当前节点值(sum-node.val)的路径总数，将其加入count。递归结束后返回count。
//在PathSum方法中对根节点调用DFS，对左右子树分别递归调用PathSum。
using System;
using System.Collections.Generic;

namespace PathSumIII
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
            Console.WriteLine("Hello World!");
        }
        static int PathSum_Recursion(TreeNode root, int sum)
        {
            if (root == null) return 0;
            return Recursion(root, sum) + PathSum_Recursion(root.left, sum) + PathSum_Recursion(root.right, sum);
        }

        static int Recursion(TreeNode node, int sum)
        {
            int count = 0;
            if (node == null) return 0;
            if (node.val == sum) count++;
            count += Recursion(node.left, sum - node.val);
            count += Recursion(node.right, sum - node.val);
            return count;
        }

        static int PathSum_PrefixSum(TreeNode root, int sum)
        {
            var res = 0;
            PrefixSum(root, new Dictionary<int, int>{{0, 1}}, 0, sum, ref res);
            return res;
        }

        static void PrefixSum(TreeNode node, Dictionary<int, int> dict, int prefix, int sum, ref int count)
        {
            if (node == null) return;
            prefix += node.val;
            if (dict.ContainsKey(prefix - sum))
                count += dict[prefix - sum];
            if (!dict.ContainsKey(prefix))
                dict[prefix] = 0;
            dict[prefix]++;
            PrefixSum(node.left, dict, prefix, sum, ref count);
            PrefixSum(node.right, dict, prefix, sum, ref count);
            dict[prefix]--;
        }
    }
}
