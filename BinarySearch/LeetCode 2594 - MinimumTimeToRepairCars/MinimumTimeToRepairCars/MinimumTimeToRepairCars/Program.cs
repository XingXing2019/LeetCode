using System;

namespace MinimumTimeToRepairCars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ranks = { 4, 2, 3, 1 };
            int cars = 10;
            Console.WriteLine(RepairCars(ranks, cars));
        }

        public static long RepairCars(int[] ranks, int cars)
        {
            long li = 1, hi = long.MaxValue;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                long count = 0;
                foreach (var rank in ranks)
                    count += (long)Math.Sqrt(mid / rank);
                if (count >= cars)
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return li;
        }
    }
}
