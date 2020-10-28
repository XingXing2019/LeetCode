//创建DFS方法辅助深度优先遍历。在board的四条边界上调用DFS，将与边界相连通的O暂时替换为*。
//遍历board将所有剩下的O替换成X，将所有*替换成O。
using System;
using System.Collections.Generic;

namespace SurroundedRegions
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[5][];
            board[0] = new char[5] { 'O', 'X', 'X', 'O', 'X' };
            board[1] = new char[5] { 'X', 'O', 'O', 'X', 'O' };
            board[2] = new char[5] { 'X', 'O', 'X', 'O', 'X' };
            board[3] = new char[5] { 'O', 'X', 'O', 'O', 'O' };
            board[4] = new char[5] { 'X', 'X', 'O', 'X', 'O' };
            Solve(board);
        }
        static void Solve_DFS(char[][] board)
        {
            if(board.Length == 0 || board[0].Length == 0) return;
            int row = board.Length, col = board[0].Length;
            var mark = new int[row][];
            for (int i = 0; i < row; i++)
                mark[i] = new int[col];
            for (int r = 0; r < row; r++)
            {
                if (board[r][0] == 'O' && mark[r][0] == 0)
                    DFS(board, mark, r, 0);
                if (board[r][col - 1] == 'O' && mark[r][col - 1] == 0)
                    DFS(board, mark, r, col - 1);
            }
            for (int c = 0; c < col; c++)
            {
                if(board[0][c] == 'O' && mark[0][c] == 0)
                    DFS(board, mark, 0, c);
                if (board[row - 1][c] == 'O' && mark[row - 1][c] == 0)
                    DFS(board, mark, row - 1, c);
            }
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (board[r][c] == 'O')
                        board[r][c] = 'X';
                    else if (board[r][c] == '*')
                        board[r][c] = 'O';
                }
            }
        }

        static void DFS(char[][] board, int[][] mark, int x, int y)
        {
            mark[x][y] = 1;
            board[x][y] = '*';
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                int newX = dx[i] + x;
                int newY = dy[i] + y;
                if (newX < 0 || newX >= board.Length || newY < 0 || newY >= board[0].Length)
                    continue;
                if (mark[newX][newY] == 0 && board[newX][newY] == 'O')
                    DFS(board, mark, newX, newY);
            }
        }

        static void Solve_BFS(char[][] board)
        {
            if (board.Length == 0 || board[0].Length == 0) return;
            var visited = new HashSet<string>();
            for (int x = 0; x < board.Length; x++)
            {
                if (board[x][0] == 'O')
                    BFS(board, visited, x, 0);
                if (board[x][^1] == 'O')
                    BFS(board, visited, x, board[0].Length - 1);
            }
            for (int y = 0; y < board[0].Length; y++)
            {
                if (board[0][y] == 'O')
                    BFS(board, visited, 0, y);
                if (board[^1][y] == 'O')
                    BFS(board, visited, board.Length - 1, y);
            }
            for (int x = 0; x < board.Length; x++)
            {
                for (int y = 0; y < board[0].Length; y++)
                {
                    if (board[x][y] == 'O' && !visited.Contains($"{x}:{y}"))
                        board[x][y] = 'X';
                }
            }
        }

        static void BFS(char[][] board, HashSet<string> visited, int x, int y)
        {
            var queue = new Queue<int[]>();
            queue.Enqueue(new[] { x, y });
            visited.Add($"{x}:{y}");
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int newX = cur[0] + dx[i];
                    int newY = cur[1] + dy[i];
                    if (newX < 0 || newX >= board.Length || newY < 0 || newY >= board[0].Length || visited.Contains($"{newX}:{newY}")) continue;
                    if (board[newX][newY] == 'O')
                    {
                        visited.Add($"{newX}:{newY}");
                        queue.Enqueue(new[] { newX, newY });
                    }
                }
            }
        }
    }
}
