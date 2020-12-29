
using System;
using System.Collections.Generic;

namespace SnakesAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] board = new int[][]
            {
                new[] {-1, -1, -1, -1, -1, -1},
                new[] {-1, -1, -1, -1, -1, -1},
                new[] {-1, -1, -1, -1, -1, -1},
                new[] {-1, 35, -1, -1, 13, -1},
                new[] {-1, -1, -1, -1, -1, -1},
                new[] {-1, 15, -1, -1, -1, -1}
            };
            Console.WriteLine(SnakesAndLadders(board));
        }
        static int SnakesAndLadders(int[][] board)
        {
            var dict = new Dictionary<int, int[]>();
            int r = board.Length - 1, c = 0;
            var increase = true;
            for (int i = 1; i <= board.Length * board.Length; i++)
            {
                dict[i] = new[] { r, c };
                c += increase ? 1 : -1;
                if (c != board.Length && c != -1) continue;
                c += increase ? -1 : 1;
                increase = !increase;
                r--;
            }
            var queue = new Queue<int[]>();
            queue.Enqueue(new[] { 1, 0 });
            var visited = new HashSet<int> { 1 };
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur[0] == board.Length * board.Length) return cur[1];
                for (int i = 1; i <= 6 && cur[0] + i <= board.Length * board.Length; i++)
                {
                    var next = cur[0] + i;
                    var pos = dict[next];
                    if (board[pos[0]][pos[1]] == -1 && visited.Add(next))
                        queue.Enqueue(new[] { next, cur[1] + 1 });
                    else if (board[pos[0]][pos[1]] != -1 && visited.Add(board[pos[0]][pos[1]]))
                        queue.Enqueue(new[] { board[pos[0]][pos[1]], cur[1] + 1 });
                }
            }
            return -1;
        }
    }
}
