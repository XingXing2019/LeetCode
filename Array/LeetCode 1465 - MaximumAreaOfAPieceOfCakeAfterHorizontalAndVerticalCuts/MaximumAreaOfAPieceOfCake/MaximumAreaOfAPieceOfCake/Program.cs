using System;

namespace MaximumAreaOfAPieceOfCake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);
            double horizontalMax = Math.Max(horizontalCuts[0], h - horizontalCuts[^1]);
            double verticalMax = Math.Max(verticalCuts[0], w - verticalCuts[^1]);
            for (int i = 1; i < horizontalCuts.Length; i++)
                horizontalMax = Math.Max(horizontalMax, horizontalCuts[i] - horizontalCuts[i - 1]);
            for (int i = 1; i < verticalCuts.Length; i++)
                verticalMax = Math.Max(verticalMax, verticalCuts[i] - verticalCuts[i - 1]);
            return (int) ((horizontalMax *  verticalMax) % (1_000_000_000 + 7));
        }
    }
}
