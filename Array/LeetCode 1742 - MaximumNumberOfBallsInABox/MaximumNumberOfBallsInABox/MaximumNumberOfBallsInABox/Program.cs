using System;
using System.Collections.Generic;

namespace MaximumNumberOfBallsInABox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountBalls(int lowLimit, int highLimit)
        {
            var dict = new Dictionary<int, int>();
            int res = 0;
            for (int i = lowLimit; i <= highLimit; i++)
            {
                int temp = 0, ball = i;
                while (ball != 0)
                {
                    temp += ball % 10;
                    ball /= 10;
                }

                if (!dict.ContainsKey(temp))
                    dict[temp] = 0;
                dict[temp]++;
                res = Math.Max(res, dict[temp]);
            }
            return res;
        }
    }
}
