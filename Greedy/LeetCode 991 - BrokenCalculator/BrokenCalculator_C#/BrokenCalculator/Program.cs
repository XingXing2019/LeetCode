using System;

namespace BrokenCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int X = 1021;
            int Y = 12321;
            Console.WriteLine(BrokenCalc(X, Y));
        }
        static int BrokenCalc(int X, int Y)
        {
            int res = 0;
            while (Y > X)
            {
                if (Y % 2 != 0)
                {
                    Y++;
                    res++;
                }
                Y /= 2;
                res++;
            }
            return res + X - Y;
        }
    }
}
