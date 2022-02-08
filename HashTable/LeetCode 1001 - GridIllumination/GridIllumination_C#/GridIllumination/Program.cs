using System;
using System.Collections.Generic;

namespace GridIllumination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        Dictionary<int, int> row = new Dictionary<int, int>();
        Dictionary<int, int> col = new Dictionary<int, int>();
        Dictionary<string, int> diagonal1 = new Dictionary<string, int>();
        Dictionary<string, int> diagonal2 = new Dictionary<string, int>();
        Dictionary<string, int> lampPosition = new Dictionary<string, int>();
        public int[] GridIllumination(int n, int[][] lamps, int[][] queries)
        {
            foreach (var lamp in lamps)
            {
                var pos = $"{lamp[0]}:{lamp[1]}";
                lampPosition.TryAdd(pos, 0);
                lampPosition[pos]++;
                row.TryAdd(lamp[0], 0);
                row[lamp[0]]++;
                col.TryAdd(lamp[1], 0);
                col[lamp[1]]++;
                var dia1 = GetDiagonal1(lamp, n);
                var dia2 = GetDiagonal2(lamp, n);
                diagonal1.TryAdd(dia1, 0);
                diagonal1[dia1]++;
                diagonal2.TryAdd(dia2, 0);
                diagonal2[dia2]++;
            }
            var res = new int[queries.Length];
            int[] dx = { 0, -1, 1, 0, 0, -1, 1, -1, 1 };
            int[] dy = { 0, 0, 0, -1, 1, -1, -1, 1, 1 };
            for (int i = 0; i < queries.Length; i++)
            {
                var dia1 = GetDiagonal1(queries[i], n);
                var dia2 = GetDiagonal2(queries[i], n);
                if (row.ContainsKey(queries[i][0]) || col.ContainsKey(queries[i][1]) || diagonal1.ContainsKey(dia1) || diagonal2.ContainsKey(dia2))
                    res[i] = 1;
                for (int j = 0; j < dx.Length; j++)
                {
                    int newX = queries[i][0] + dx[j], newY = queries[i][1] + dy[j];
                    if (!lampPosition.ContainsKey($"{newX}:{newY}")) continue;
                    TurnOffLamp(new[] { newX, newY }, n);
                }
            }
            return res;
        }

        public void TurnOffLamp(int[] lamp, int n)
        {
            var pos = $"{lamp[0]}:{lamp[1]}";
            var count = lampPosition[pos];
            lampPosition.Remove(pos);
            row[lamp[0]] -= count;
            if (row[lamp[0]] == 0) row.Remove(lamp[0]);
            col[lamp[1]] -= count;
            if (col[lamp[1]] == 0) col.Remove(lamp[1]);
            var dia1 = GetDiagonal1(lamp, n);
            var dia2 = GetDiagonal2(lamp, n);
            diagonal1[dia1] -= count;
            if (diagonal1[dia1] == 0) diagonal1.Remove(dia1);
            diagonal2[dia2] -= count;
            if (diagonal2[dia2] == 0) diagonal2.Remove(dia2);
        }

        public static string GetDiagonal1(int[] lamp, int n)
        {
            int x = lamp[0], y = lamp[1];
            int[] p1 = { x - Math.Min(x, y), y - Math.Min(x, y) };
            int[] p2 = { x + Math.Min(n - x, n - y), y + Math.Min(n - x, n - y) };
            return $"{p1[0]}:{p1[1]}:{p2[0]}:{p2[1]}";
        }

        public static string GetDiagonal2(int[] lamp, int n)
        {
            int x = lamp[0], y = lamp[1];
            int[] p1 = { x - Math.Min(x, n - y), y + Math.Min(x, n - y) };
            int[] p2 = { x + Math.Min(y, n - x), y - Math.Min(y, n - x) };
            return $"{p1[0]}:{p1[1]}:{p2[0]}:{p2[1]}";
        }
    }
}
