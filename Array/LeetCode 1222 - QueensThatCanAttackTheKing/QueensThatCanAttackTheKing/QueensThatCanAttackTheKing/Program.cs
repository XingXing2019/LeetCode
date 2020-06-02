//创建二位数组board记录queen的位置，遍历queens，将每个queen的坐标在board中标记为1。
//从King坐标出发向八个方向遍历，找到在每个方向上最近的queen的坐标，将其记录入res。
using System;
using System.Collections.Generic;

namespace QueensThatCanAttackTheKing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] queens = new int[6][];
            queens[0] = new int[2] { 0, 1 };
            queens[1] = new int[2] { 1, 0 };
            queens[2] = new int[2] { 4, 0 };
            queens[3] = new int[2] { 0, 4 };
            queens[4] = new int[2] { 3, 3 };
            queens[5] = new int[2] { 2, 4 };
            int[] king = { 0, 0 };
            Console.WriteLine(QueensAttacktheKing(queens, king));
        }
        static IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
            var res = new List<IList<int>>();
            int[,] board = new int[8, 8];
            foreach (var q in queens)
                board[q[0], q[1]] = 1;
            for (int i = king[0] + 1; i < 8; i++)
            {
                if(board[i, king[1]] == 1)
                {
                    res.Add(new int[2] { i, king[1] });
                    break;
                }
            }
            for (int i = king[0] - 1; i >= 0; i--)
            {
                if (board[i, king[1]] == 1)
                {
                    res.Add(new int[2] { i, king[1] });
                    break;
                }
            }
            for (int i = king[1] + 1; i < 8; i++)
            {
                if(board[king[0], i] == 1)
                {
                    res.Add(new int[2] { king[0], i });
                    break;
                }
            }
            for (int i = king[1] - 1; i >= 0; i--)
            {
                if (board[king[0], i] == 1)
                {
                    res.Add(new int[2] { king[0], i });
                    break;
                }
            }
            for (int i = 1; king[0] + i < 8 && king[1] + i < 8; i++)
            {
                if(board[king[0] + i,king[1] + i] == 1)
                {
                    res.Add(new int[2] { king[0] + i, king[1] + i });
                    break;
                }
            }
            for (int i = 1; king[0] - i >= 0 && king[1] - i >= 0; i++)
            {
                if (board[king[0] - i, king[1] - i] == 1)
                {
                    res.Add(new int[2] { king[0] - i, king[1] - i });
                    break;
                }
            }
            for (int i = 1; king[0] - i >= 0 && king[1] + i < 8; i++)
            {
                if(board[king[0] - i, king[1] + i] == 1)
                {
                    res.Add(new int[2] { king[0] - i, king[1] + i });
                    break;
                }
            }
            for (int i = 1; king[0] + i < 8 && king[1] - i >=0; i++)
            {
                if(board[king[0] + i, king[1] - i] == 1)
                {
                    res.Add(new int[2] { king[0] + i, king[1] - i });
                    break;
                }
            }
            return res;
        }
    }
}
