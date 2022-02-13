
using System;
using System.Linq;

namespace RemovingMinimumNumberOfMagicBeans
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] beans = { 6, 9, 9, 7, 3 };
            Console.WriteLine(MinimumRemoval(beans));
        }

        public static long MinimumRemoval(int[] beans)
        {
            var record = beans.GroupBy(x => x).OrderBy(x => x.Key).Select(x => new [] { x.Key, x.Count(), (long) x.Key * x.Count() }).ToArray();
            for (int i = 1; i < record.Length; i++)
            {
                record[i][1] += record[i - 1][1];
                record[i][2] += record[i - 1][2];
            }
            var res = long.MaxValue;
            for (int i = 0; i < record.Length; i++)
            {
                var less = i == 0 ? 0 : record[i - 1][2];
                var greater = i == record.Length - 1 ? 0 : record[^1][2] - record[i][2] - record[i][0] * (record[^1][1] - record[i][1]);
                res = Math.Min(res, less + greater);
            }
            return res;
        }
    }
}
