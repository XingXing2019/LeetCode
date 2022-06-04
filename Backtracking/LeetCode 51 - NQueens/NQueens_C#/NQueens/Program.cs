//经典递归加回溯算法。创建mark数组用于记录已放置皇后的攻击范围。创建方法PutDownQueen用于更新mark数组。利用方向数组可以减少代码量。
//创建Generate方法放置皇后。传入参数k代表正在放置第几个皇后(也就是现在在第几行)，n代表一共有几个皇后需要放置，location记录当前棋盘各个位置的状态(使用StringBulider数组，便于修改)。res记录结果。mark记录皇后的攻击范围(不能放置皇后的位置)。
//当k等于n时，证明可以把n个皇后全部放下。此时将当前location的状态记录如一个string列表，并添加到res中。
//否则在该行的每一列上(n)循环，试图找到下一个能放置皇后的位置。如果某一位置在mark中为0，则该位置可以放置皇后。则先创建一个temMark数组记录当前mark数组状态，方便回溯时还原mark数组。
//再将location中该位置设为Q，并调用PutDownQueen方法更新mark。然后递归调用Generate，将k+1传入，尝试下一行。
//递归返回后，利用temMark将mark回复上一状态，并将location中该位置恢复为'.'。
//在主方法中调用Generate，将0作为k传入。
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            Console.WriteLine(SolveNQueens(n));
        }
        static IList<IList<string>> SolveNQueens(int n)
        {
            var res = new List<IList<string>>();
            var locations = new char[n][];
            var board = new int[n][];
            for (int r = 0; r < n; r++)
            {
                board[r] = new int[n];
                locations[r] = new char[n];
                for (int c = 0; c < n; c++)
                    locations[r][c] = '.';
            }
            DFS(0, n, locations, board, res);
            return res;
        }

        static void UpdateBoard(int r, int c, int n, int[][] board)
        {
            int[] dx = {-1, 1, 0, 0, -1, 1, -1, 1};
            int[] dy = {0, 0, -1, 1, -1, -1, 1, 1};
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int newR = r + dx[j] * i;
                    int newC = c + dy[j] * i;
                    if(newR < 0 || newR >= n ||newC < 0 || newC >= n) continue;
                    board[newR][newC] = 1;
                }
            }
        }

        static void DFS(int r, int n, char[][] locations, int[][] board, List<IList<string>> res)
        {
            if (r == n)
            {
                res.Add(locations.Select(location => string.Join("", location)).ToList());
                return;
            }
            for (int c = 0; c < n; c++)
            {
                if(board[r][c] == 1) continue;
                var record = new int[n][];
                for (int j = 0; j < record.Length; j++)
                {
                    record[j] = new int[n];
                    Array.Copy(board[j], record[j], n);
                }
                locations[r][c] = 'Q';
                UpdateBoard(r, c, n, board);
                DFS(r + 1, n, locations, board, res);
                locations[r][c] = '.';
                board = record;
            }
        }
    }
}
