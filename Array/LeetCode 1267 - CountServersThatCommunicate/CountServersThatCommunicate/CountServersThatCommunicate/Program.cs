using System;
using System.Collections.Generic;
using System.Linq;

namespace CountServersThatCommunicate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int CountServers(int[][] grid)
        {
            var servers = new HashSet<int>();
            int row = grid.Length, col = grid[0].Length;
            for (int r = 0; r < row; r++)
            {
                int count = 0;
                for (int c = 0; c < col; c++)
                    count += grid[r][c];
                if (count > 1)
                {
                    for (int c = 0; c < col; c++)
                    {
                        if (grid[r][c] == 1)
                            servers.Add(r * 1000 + c);
                    }
                }
            }
            for (int c = 0; c < col; c++)
            {
                int count = 0;
                for (int r = 0; r < row; r++)
                    count += grid[r][c];
                if (count > 1)
                {
                    for (int r = 0; r < row; r++)
                    {
                        if (grid[r][c] == 1)
                            servers.Add(r * 1000 + c);
                    }
                }
            }
            return servers.Count;
        }
    }
}
