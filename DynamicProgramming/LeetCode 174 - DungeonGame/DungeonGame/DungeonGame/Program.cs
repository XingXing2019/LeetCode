//关键需要从右下往左上遍历。这样才能得到进入每个房间所需的最少血量。
//创建二维数组minEnterHP， 大小与dungeon相同，代表要进入每个房间前所需的最小血量。
//将minEnterHP右下角一点初始值设为1与1-dungeon右下角两个数中较大的一个。因为dungeon右下角数字可能为正负或者0，
//如果为正或者0，证明进入这个房间不会减血，则只需保持基本血量为1即可。如为负，证明进入该房间会减血，则需保持基本血量应为该房间减血量加1。
//将minEnterHP最下面一行，除去右下角一点其余所有元素更新为1和其右面数字与dungeon该点数字之差中较大的一个，代表如果失去该房间对应的血量，仍有足够血量进去下一房间。
//对minEnterHP最右一列做同样操作。完成动态数组边界条件初始化。
//动态遍历minEnterHP数组中其他元素。path1为1和该点右面数字与dungeon该点数字之差中较大的一个。path2为1和该点下面数字与dungeon该点数字之差中较大的一个。该点为path1与path2中较小的数。
//最后返回minEnterHP左上角数字即为结果。
using System;

namespace DungeonGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] dungeon = new int[2][];
            dungeon[0] = new int[] { 2, 1 };
            dungeon[1] = new int[] { 1, -1 };
            Console.WriteLine(CalculateMinimumHP(dungeon));
        }
        static int CalculateMinimumHP(int[][] dungeon)
        {
            int row = dungeon.Length;
            int col = dungeon[0].Length;
            int[,] minEnterHP = new int[row, col];
            minEnterHP[row - 1, col - 1] = Math.Max(1, 1 - dungeon[row - 1][col - 1]);
            for (int r = row - 2; r >= 0; r--)
                minEnterHP[r, col - 1] = Math.Max(1, minEnterHP[r + 1, col - 1] - dungeon[r][col - 1]);
            for (int c = col - 2; c >= 0; c--)
                minEnterHP[row - 1, c] = Math.Max(1, minEnterHP[row - 1, c + 1] - dungeon[row - 1][c]);
            for (int r = row - 2; r >= 0; r--)
            {
                for (int c = col - 2; c >= 0; c--)
                {
                    int path1 = Math.Max(1, minEnterHP[r + 1, c] - dungeon[r][c]);
                    int path2 = Math.Max(1, minEnterHP[r, c + 1] - dungeon[r][c]);
                    minEnterHP[r, c] = Math.Min(path1, path2);
                }
            }                
            return minEnterHP[0, 0];
        }
    }
}
