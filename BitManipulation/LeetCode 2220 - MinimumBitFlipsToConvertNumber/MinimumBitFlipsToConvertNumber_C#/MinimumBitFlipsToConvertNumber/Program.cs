using System;

namespace MinimumBitFlipsToConvertNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinBitFlips(int start, int goal)
        {
            var res = 0;
            while (start != 0 && goal != 0)
            {
                if ((start & 1) != (goal & 1))
                    res++;
                start >>= 1;
                goal >>= 1;
            }
            while (start != 0)
            {
                if ((start & 1) != 0)
                    res++;
                start >>= 1;
            }
            while (goal != 0)
            {
                if ((goal & 1) != 0)
                    res++;
                goal >>= 1;
            }
            return res;
        }
    }
}
