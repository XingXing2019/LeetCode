using System;

namespace DeleteColumnsToMakeSortedII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strs = { "btw", "etm", "ezl", "niv" };
            Console.WriteLine(MinDeletionSize(strs));
        }

        public static int MinDeletionSize(string[] strs)
        {
            int m = strs.Length, n = strs[0].Length, res = 0;
            var state = new int[m];
            for (int j = 0; j < n; j++)
            {
                var copy = new int[m];
                Array.Copy(state, copy, m);
                for (int i = 1; i < m; i++)
                {
                    if (state[i] == 1) continue;
                    if (strs[i][j] > strs[i - 1][j])
                        state[i] = 1;
                    else if (strs[i][j] == strs[i - 1][j])
                        state[i] = 0;
                    else
                    {
                        state = copy;
                        res++;
                        break;
                    }
                }
            }
            return res;
        }
    }
}
