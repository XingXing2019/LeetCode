using System;

namespace FrogJumpII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] stones = { 0, 2, 5, 6, 7 };
            Console.WriteLine(MaxJump(stones));
        }

        public static int MaxJump(int[] stones)
        {
            var max = 0;
            for (int i = 2; i < stones.Length; i += 2)
                max = Math.Max(max, stones[i] - stones[i - 2]);
            for (int i = 3; i < stones.Length; i += 2)
                max = Math.Max(max, stones[i] - stones[i - 2]);
            return Math.Max(max, Math.Max(stones[^1] - stones[^2], stones[1] - stones[0]));
        }
    }
}
