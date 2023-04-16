using System;
using System.Linq;

namespace RowWithMaximumOnes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] RowAndMaximumOnes(int[][] mat)
        {
            int res = 0, max = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                var count = mat[i].Count(x => x == 1);
                if (count <= max) continue;
                res = i;
                max = count;
            }
            return new[] { res, max };
        }
    }
}
