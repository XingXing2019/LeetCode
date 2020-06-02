//本题应用动态规划思想。想象在一个棋盘上，到达每个点路径的数量，就是到达该点上面一个点路径的数量加上达到该点左边一个点路径的数量。
//沿着棋盘宽和高边缘的一行和一列，由于他们没有上面的点和左面的点，所以到达他们路径的数量都为1。
//创建一个二维数组，代表m * n的一个棋盘。先将他最上面的一行和最左边的一列上所有列都设为1。
//遍历这个棋盘，到达遍历到的点的路径的数量就是能到达他上面点和左面点路径数量的总和：countPath[i, j] = countPath[i - 1, j] + countPath[i, j - 1]
//遍历结束后则该棋盘上所有的点都已经赋值。则返回终点处的值即可。
using System;

namespace UniquePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 0;
            int n = 0;
            Console.WriteLine(UniquePaths(m, n));
        }
        static int UniquePaths(int m, int n)
        {
            int[,] countPath = new int[m, n];
            for (int i = 0; i < n; i++)
                countPath[0, i] = 1;
            for (int i = 0; i < m; i++)
                countPath[i, 0] = 1;
            for (int i = 1; i < m; i++)
                for (int j = 1; j < n; j++)
                    countPath[i, j] = countPath[i - 1, j] + countPath[i, j - 1];
            return countPath[m - 1, n - 1];
        }
    }
}
