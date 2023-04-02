using System;

namespace MiceAndCheese
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MiceAndCheese(int[] reward1, int[] reward2, int k)
        {
            var points = new int[reward1.Length][];
            for (int i = 0; i < reward1.Length; i++)
                points[i] = new[] { reward1[i] - reward2[i], i };
            Array.Sort(points, (a, b) => b[0] - a[0]);
            var res = 0;
            for (int i = 0; i < points.Length; i++)
            {
                var index = points[i][1];
                res += i < k ? reward1[index] : reward2[index];
            }
            return res;
        }
    }
}
