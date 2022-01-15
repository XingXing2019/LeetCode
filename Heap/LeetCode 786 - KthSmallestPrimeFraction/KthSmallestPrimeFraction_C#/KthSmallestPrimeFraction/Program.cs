using System;
using System.Linq;

namespace KthSmallestPrimeFraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] KthSmallestPrimeFraction(int[] arr, int k)
        {
            var count = arr.Length * (arr.Length - 1) / 2;
            var pairs = new double[count][];
            var index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    pairs[index++] = new double[] { arr[i], arr[j] };
                }
            }
            pairs = pairs.OrderBy(x => x[0] / x[1]).ToArray();
            return new int[] { (int)pairs[k - 1][0], (int)pairs[k - 1][1] };
        }
    }
}
