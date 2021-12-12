using System;

namespace WateringPlantsII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] plants = { 7, 7, 9, 1, 9, 8 };
            int capacityA = 14, capacityB = 12;
            Console.WriteLine(MinimumRefill(plants, capacityA, capacityB));
        }

        public static int MinimumRefill(int[] plants, int capacityA, int capacityB)
        {
            int alice = capacityA, bob = capacityB;
            int li = 0, hi = plants.Length - 1, res = 0;
            while (li < hi)
            {
                if (alice < plants[li])
                {
                    alice = capacityA;
                    res++;
                }
                alice -= plants[li++];
                if (bob < plants[hi])
                {
                    bob = capacityB;
                    res++;
                }
                bob -= plants[hi--];
                if (li == hi && Math.Max(alice, bob) < plants[li])
                    res++;
            }
            return res;
        }
    }
}
