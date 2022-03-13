
using System;
using System.Collections.Generic;
using System.Linq;

namespace LonelyPixelII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int FindBlackPixel(char[][] picture, int target)
        {
            var rows = new int[picture.Length];
            var cols = new int[picture[0].Length];
            var patterns = new string[picture.Length];
            var res = 0;
            for (int r = 0; r < picture.Length; r++)
            {
                var count = 0;
                for (int c = 0; c < picture[0].Length; c++)
                    if (picture[r][c] == 'B') count++;
                rows[r] = count;
                patterns[r] = string.Join("", picture[r]);
            }
            for (int c = 0; c < picture[0].Length; c++)
            {
                var count = 0;
                for (int r = 0; r < picture.Length; r++)
                    if (picture[r][c] == 'B') count++;
                cols[c] = count;
            }
            for (int r = 0; r < picture.Length; r++)
            {
                for (int c = 0; c < picture[0].Length; c++)
                {
                    if (picture[r][c] != 'B' || rows[r] != target || cols[c] != target)
                        continue;
                    var pattern = string.Join("", picture[r]);
                    if (!picture.Where((row, i) => row[c] == 'B' && patterns[i] != pattern).Any()) 
                        res++;
                }
            }
            return res;
        }
    }
}
