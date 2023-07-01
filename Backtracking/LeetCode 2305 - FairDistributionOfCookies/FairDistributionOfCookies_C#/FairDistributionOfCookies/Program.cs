using System;
using System.Linq;

namespace FairDistributionOfCookies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cookies = { 6, 1, 3, 2, 2, 4, 1, 2 };
            int k = 3;
            Console.WriteLine(DistributeCookies(cookies, k));
        }

        public static int DistributeCookies(int[] cookies, int k)
        {
            var res = int.MaxValue;
            Array.Sort(cookies);
            DFS(cookies, 0, new int[k], ref res);
            return res;
        }

        public static void DFS(int[] cookies, int index, int[] bucket, ref int res)
        {
            if (index == cookies.Length)
            {
                res = Math.Min(res, bucket.Max());
                return;
            }
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] += cookies[index];
                DFS(cookies, index + 1, bucket, ref res);
                bucket[i] -= cookies[index];
            }
        }
    }
}
