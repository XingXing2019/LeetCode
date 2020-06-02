//创建record字典，记录gap出现的位置，和在该位置gap出现的次数。
//遍历wall的每一行，计算gap出现的位置，统计在某个位置上gap出现的次数计入record。哪个位置gap出现的最多，则从该位置划线，穿过的砖最少。
//遍历record统计出了两个边缘以外的位置，gap出现最多的次数。返回行数减去gap出现的次数。
using System;
using System.Collections.Generic;

namespace BrickWall
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] wall = new int[6][];
            wall[0] = new int[] { 1, 2, 2, 1 };
            wall[1] = new int[] { 3, 1, 2 };
            wall[2] = new int[] { 1, 3, 2 };
            wall[3] = new int[] { 2, 4 };
            wall[4] = new int[] { 3, 1, 2 };
            wall[5] = new int[] { 1, 3, 1, 1 };
            Console.WriteLine(LeastBricks(wall));
        }
        static int LeastBricks(IList<IList<int>> wall)
        {
            int row = wall.Count;
            int width = 0;
            for (int c = 0; c < wall[0].Count; c++)
                width += wall[0][c];
            var record = new Dictionary<int, int>();
            for (int r = 0; r < wall.Count; r++)
            {
                int tem = 0;
                for (int c = 0; c < wall[r].Count; c++)
                {
                    if (!record.ContainsKey(tem))
                        record[tem] = 1;
                    else
                        record[tem]++;
                    tem += wall[r][c];
                }
            }
            int maxGaps = 0;
            foreach (var kv in record)
                if (kv.Key != 0 && kv.Key != width)
                    maxGaps = Math.Max(maxGaps, kv.Value);
            return row - maxGaps;
        }

    }
}
