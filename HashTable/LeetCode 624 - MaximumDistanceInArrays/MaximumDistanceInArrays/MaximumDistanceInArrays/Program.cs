using System;
using System.Collections.Generic;

namespace MaximumDistanceInArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxDistance(IList<IList<int>> arrays)
        {
            int min = arrays[0][0], max = arrays[0][^1], res = 0;
            for (int i = 1; i < arrays.Count; i++)
            {
                res = Math.Max(res, Math.Max(Math.Abs(arrays[i][^1] - min), Math.Abs(max - arrays[i][0])));
                min = Math.Min(min, arrays[i][0]);
                max = Math.Max(max, arrays[i][^1]);
            }
            return res;
        }
    }
}
