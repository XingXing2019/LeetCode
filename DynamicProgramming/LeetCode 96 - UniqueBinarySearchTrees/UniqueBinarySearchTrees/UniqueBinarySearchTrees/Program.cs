//BST特点是根节点左子树的所有值都小于根节点，右子树的所有值都大于根节点。
//所以0到n任意值i为根节点的BST，左子树的个数为0到i-1能构成BST的个数，右子树为i+1到n能构成BST的个数。所以以i为根节点能构成BST的个数为而这乘积。
//创建dp数组代表以dp[i]为根节点能构成BST的个数。dp[0]设为1(空树)，dp[1]设为1。
//从i=2开始遍历，记录0到i之间以每个j为根节点能构成BST的个数。将dp[i]设为个数的总和。
using System;

namespace UniqueBinarySearchTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            Console.WriteLine(NumTrees(n));
        }
        static int NumTrees(int n)
        {
            if(n == 0) return 1;
            var dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i < dp.Length; i++)
            {
                var count = 0;
                for (int j = 0; j < i; j++)
                {
                    count += dp[j] * dp[i - j - 1];
                    dp[i] = count;
                }
            }
            return dp[^1];
        }
    }
}
