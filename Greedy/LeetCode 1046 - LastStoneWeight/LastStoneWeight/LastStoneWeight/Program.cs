using System;

namespace LastStoneWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stones = { 2, 7, 4, 1, 8, 1 };
            Console.WriteLine(LastStoneWeight(stones));
        }
        static int LastStoneWeight(int[] stones)
        {
            int len = stones.Length;
            for (int i = 0; i < len - 1; i++)
            {
                Array.Sort(stones);
                if (stones[len - 1] == stones[len - 2])
                {
                    stones[len - 1] = 0;
                    stones[len - 2] = 0;
                }
                else
                {
                    stones[len - 1] -= stones[len - 2];
                    stones[len - 2] = 0;
                }
            }
            Array.Sort(stones);
            return stones[len - 1];
        }
    }
}
