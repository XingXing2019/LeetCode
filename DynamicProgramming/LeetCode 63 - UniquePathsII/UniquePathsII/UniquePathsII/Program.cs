//动态规划思路。先判断原点是否为1(障碍)，如果为1则直接返回0，否则将原点设为1(代表有一种走法)。创建m和n代表棋盘的宽和高。
//遍历原点右边和下边的所有点，如果为1(障碍)，则将该点设为0，代表走到该点有0中走法，如果不为1，则将该点设为其左边或者上边相同(如果左边或者上边为0，则证明该点之前有障碍物，则该点肯定走不到，则设为0)。
//设置好边界条件后，则遍历棋盘的其他点。如果遍历到的点为1(障碍)，则将该点设为0。否则将到达该点的走法数设为其左边点和上边点走法数的总和。
//最后返回终点的走法总数。
using System;

namespace UniquePathsII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] obstacleGrid = new int[3][];
            obstacleGrid[0] = new int[] { 0, 0, 0 };
            obstacleGrid[1] = new int[] { 0, 1, 0 };
            obstacleGrid[2] = new int[] { 0, 0, 0 };
            Console.WriteLine(UniquePathsWithObstacles(obstacleGrid));
        }
        static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid[0][0] == 1)
                return 0;
            obstacleGrid[0][0] = 1;
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;
            for (int i = 1; i < n; i++)
            {
                if (obstacleGrid[0][i] == 1)
                    obstacleGrid[0][i] = 0;
                else
                    obstacleGrid[0][i] = obstacleGrid[0][i - 1];
            }
            for (int i = 1; i < m; i++)
            {
                if (obstacleGrid[i][0] == 1)
                    obstacleGrid[i][0] = 0;
                else
                    obstacleGrid[i][0] = obstacleGrid[i - 1][0];
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                        obstacleGrid[i][j] = 0;
                    else
                        obstacleGrid[i][j] = obstacleGrid[i - 1][j] + obstacleGrid[i][j - 1];
                }
            }
            return obstacleGrid[m - 1][n - 1];
        }
    }
}
