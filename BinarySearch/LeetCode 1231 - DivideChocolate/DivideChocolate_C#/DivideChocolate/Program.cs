
using System;
using System.Linq;

namespace DivideChocolate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sweetness = { 1, 2, 3, 4, 5, 6 };
            int k = 1;
            Console.WriteLine(MaximizeSweetness(sweetness, k));
        }

        public static int MaximizeSweetness(int[] sweetness, int k)
        {
            int li = sweetness.Min(), hi = sweetness.Sum();
            while (li <= hi)
            {
                int mid = li + (hi - li) / 2;
                int count = 0, part = 0;
                foreach (var s in sweetness)
                {
                    if (part < mid)
                        part += s;
                    else
                    {
                        part = s;
                        count++;
                    }
                }
                if (part >= mid) count++;
                if (count < k + 1)
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return hi;
        }
    }
}
