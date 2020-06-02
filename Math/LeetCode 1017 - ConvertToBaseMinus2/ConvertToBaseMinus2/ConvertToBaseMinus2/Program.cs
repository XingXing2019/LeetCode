using System;

namespace ConvertToBaseMinus2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 2;
            Console.WriteLine(BaseNeg2(N));
        }
        static string BaseNeg2(int N)
        {
            if (N == 0)
                return "0";
            var res = "";
            while (N != 0)
            {
                int reminder = N % -2;
                N /= -2;
                if (reminder < 0)
                {
                    N += 1;
                    reminder += 2;
                }
                res = reminder + res;
            }
            return res;
        }
    }
}
