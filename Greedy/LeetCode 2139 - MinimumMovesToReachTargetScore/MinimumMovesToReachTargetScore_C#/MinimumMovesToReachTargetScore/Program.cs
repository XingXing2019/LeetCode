using System;

namespace MinimumMovesToReachTargetScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinMoves(int target, int maxDoubles)
        {
            var res = 0;
            while (target != 1 && maxDoubles != 0)
            {
                if (target % 2 == 0)
                {
                    target /= 2;
                    maxDoubles--;
                }
                else
                    target--;
                res++;
            }
            return res + (target - 1);
        }
    }
}
