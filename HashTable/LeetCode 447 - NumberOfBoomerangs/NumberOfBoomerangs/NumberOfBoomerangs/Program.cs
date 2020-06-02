using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfBoomerangs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] points = new int[3][];
            points[0] = new int[] {0, 0};
            points[1] = new int[] {1, 0};
            points[2] = new int[] {2, 0};
            Console.WriteLine(NumberOfBoomerangs(points));
        }
        static int NumberOfBoomerangs(int[][] points)
        {
            int res = 0;
            for (int i = 0; i < points.Length; i++)
            {
                Dictionary<int, int> record = new Dictionary<int, int>();
                for (int j = 0; j < points.Length; j++)
                {
                    if(i == j)
                        continue;
                    int d = (points[i][0] - points[j][0]) * (points[i][0] - points[j][0]) +
                            (points[i][1] - points[j][1]) * (points[i][1] - points[j][1]);
                    if (!record.ContainsKey(d))
                        record[d] = 1;
                    else
                        record[d]++;
                }
                res += record.Sum(r => r.Value * (r.Value - 1));
            }
            return res;
        }
    }
}
