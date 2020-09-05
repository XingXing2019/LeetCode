using System;
using System.Collections.Generic;

namespace BombEnemy
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] grid = new[]
            {
                new[] {'0', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'W'}
            };
            Console.WriteLine(MaxKilledEnemies(grid));
        }
        static int MaxKilledEnemies(char[][] grid)
        {
            var res = 0;
            if (grid.Length == 0 || grid[0].Length == 0) return res;
            var rowKill = new Dictionary<int, List<int[]>>();
            var colKill = new Dictionary<int, List<int[]>>();
            var bombs = new List<int[]>();
            for (int r = 0; r < grid.Length; r++)
            {
                if (!rowKill.ContainsKey(r))
                    rowKill[r] = new List<int[]>();
                var count = 0;
                for (int c = 0; c < grid[0].Length; c++)
                {
                    if(grid[r][c] == '0')
                        bombs.Add(new []{r, c});
                    else if (grid[r][c] == 'E')
                        count++;
                    else
                    {
                        rowKill[r].Add(new []{c, count});
                        count = 0;
                    }
                }
                rowKill[r].Add(new[] { grid[0].Length, count });
            }
            for (int c = 0; c < grid[0].Length; c++)
            {
                if (!colKill.ContainsKey(c))
                    colKill[c] = new List<int[]>();
                var count = 0;
                for (int r = 0; r < grid.Length; r++)
                {
                    if (grid[r][c] == 'E')
                        count++;
                    else if (grid[r][c] == 'W')
                    {
                        colKill[c].Add(new []{r, count});
                        count = 0;
                    }
                }
                colKill[c].Add(new[] { grid.Length, count });
            }
            foreach (var bomb in bombs)
            {
                int kills = 0;
                if (rowKill.ContainsKey(bomb[0]))
                {
                    var temp = rowKill[bomb[0]];
                    int pos = BinarySearch(temp, bomb[1]);
                    kills += temp[pos][1];
                }
                if (colKill.ContainsKey(bomb[1]))
                {
                    var temp = colKill[bomb[1]];
                    int pos = BinarySearch(temp, bomb[0]);
                    kills += temp[pos][1];
                }
                res = Math.Max(res, kills);
            }
            return res;
        }

        static int BinarySearch(List<int[]> list, int target)
        {
            int li = 0, hi = list.Count - 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (list[mid][0] > target)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return li;
        }
    }
}
