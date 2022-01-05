using System;

namespace CatAndMouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int CatMouseGame(int[][] graph)
        {
            var dp = new int[graph.Length * 2][][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[graph.Length][];
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = new int[graph.Length];
                    Array.Fill(dp[i][j], -1);
                }
            }
            return DFS(graph, dp, 0, 1, 2);
        }

        public static int DFS(int[][] graph, int[][][] dp, int turn, int mouse, int cat)
        {
            if (turn == graph.Length * 2) return 0;
            if (mouse == 0) return 1;
            if (cat == mouse) return 2;
            if (dp[turn][mouse][cat] != -1) return dp[turn][mouse][cat];
            if (turn % 2 == 0)
            {
                var catWin = true;
                foreach (var mouseNext in graph[mouse])
                {
                    var next = DFS(graph, dp, turn + 1, mouseNext, cat);
                    if (next == 1)
                        return dp[turn][mouse][cat] = 1;
                    if (next != 2)
                        catWin = false;
                }
                dp[turn][mouse][cat] = catWin ? 2 : 0;
            }
            else
            {
                var mouseWin = true;
                foreach (var nextCat in graph[cat])
                {
                    if (nextCat == 0) continue;
                    var next = DFS(graph, dp, turn + 1, mouse, nextCat);
                    if (next == 2)
                        return dp[turn][mouse][cat] = 2;
                    if (next != 1)
                        mouseWin = false;
                }
                dp[turn][mouse][cat] = mouseWin ? 1 : 0;
            }
            return dp[turn][mouse][cat];
        }
    }
}
