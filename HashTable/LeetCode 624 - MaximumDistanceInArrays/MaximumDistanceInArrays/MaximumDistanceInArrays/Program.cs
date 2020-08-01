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
            var record = new int[arrays.Count][];
            for (int r = 0; r < arrays.Count; r++)
                record[r] = new int[]{arrays[r][0], int.MinValue};
            for (int i = 0; i < arrays.Count; i++)
            {
                for (int j = 0; j < record.Length; j++)
                {
                    if(i == j) continue;
                    record[j][1] = Math.Max(record[j][1], arrays[i][^1]);
                }
            }
            var res = int.MinValue;
            for (int i = 0; i < record.Length; i++)
                res = Math.Max(res, record[i][1] - record[i][0]);
            return res;
        }
    }
}
