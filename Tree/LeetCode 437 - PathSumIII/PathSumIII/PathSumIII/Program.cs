//创建DFS辅助递归遍历，思路为以当前节点作为根节点，向下寻找满足和为sum的路径总数。
//当前节点为空的时候证明已经到树顶，往下没有可以满足条件的路径，则返回0。
//否则递归遍历当前节点一下的左子树和右子树，寻找能满足和为sum减去当前节点值(sum-node.val)的路径总数，将其加入count。递归结束后返回count。
//在PathSum方法中对根节点调用DFS，对左右子树分别递归调用PathSum。
using System;

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
        static int PathSum(TreeNode root, int sum)
        {
            if (root == null) 
                return 0;
            return DFS(root, sum) + PathSum(root.left, sum) + PathSum(root.right, sum);
        }
        static int DFS(TreeNode node, int sum)
        {
            int count = 0;
            if (node == null) 
                return 0;
            if (node.val == sum)
                count++;
            count += DFS(node.left, sum - node.val);
            count += DFS(node.right, sum - node.val);
            return count;
        }
    }
}
