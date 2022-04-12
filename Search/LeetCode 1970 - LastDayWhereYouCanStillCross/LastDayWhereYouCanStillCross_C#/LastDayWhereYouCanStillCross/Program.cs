using System;
using System.Data;

namespace LastDayWhereYouCanStillCross
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = 3, col = 3;
            int[][] cells = new[]
            {
                new[] { 1, 2 },
                new[] { 2, 1 },
                new[] { 3, 3 },
                new[] { 2, 2 },
                new[] { 1, 1 },
                new[] { 1, 3 },
                new[] { 2, 3 },
                new[] { 3, 2 },
                new[] { 3, 1 },
            };
            Console.WriteLine(LatestDayToCross(row, col, cells));
        }

        public static int LatestDayToCross(int row, int col, int[][] cells)
        {
            int li = 0, hi = cells.Length;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                var board = MakeBoard(row, col, mid, cells);
                var canReach = false;
                for (int y = 0; y < col; y++)
                {
                    var visited = new bool[row][];
                    for (int i = 0; i < row; i++)
                        visited[i] = new bool[col];
                    if (!DFS(board, visited, 0, y)) continue;
                    canReach = true;
                    break;
                }
                if (!canReach) hi = mid - 1;
                else li = mid + 1;
            }
            return hi;
        }

        public static bool DFS(int[][] board, bool[][] visited, int x, int y)
        {
            int m = board.Length, n = board[0].Length;
            if (x < 0 || x >= m || y < 0 || y >= n || visited[x][y] || board[x][y] == 1)
                return false;
            if (x == m - 1)
                return true;
            visited[x][y] = true;
            return DFS(board, visited, x + 1, y) ||
                   DFS(board, visited, x - 1, y) ||
                   DFS(board, visited, x, y + 1) ||
                   DFS(board, visited, x, y - 1);
        }

        public static int[][] MakeBoard(int row, int col, int day, int[][] cells)
        {
            var board = new int[row][];
            for (int i = 0; i < row; i++)
                board[i] = new int[col];
            for (int i = 0; i < day; i++)
            {
                int x = cells[i][0] - 1, y = cells[i][1] - 1;
                board[x][y] = 1;
            }
            return board;
        }
    }
}
