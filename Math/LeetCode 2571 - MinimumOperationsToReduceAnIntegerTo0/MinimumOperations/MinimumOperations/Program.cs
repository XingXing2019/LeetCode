using System;

namespace MinimumOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 84;
            Console.WriteLine(MinOperations(n));
        }
        public static int MinOperations(int n)
        {
            int res = 0, countOne = 0;
            while (n != 0)
            {
                var digit = n % 2;
                n /= 2;
                if (digit == 1)
                    countOne++;
                else if (countOne != 0)
                {
                    if (n % 2 != 0)
                    {
                        if (countOne == 1)
                            countOne = 0;
                        res++;
                    }
                    else
                    {
                        res += countOne == 1 ? 1 : 2;
                        countOne = 0;
                    }
                }
            }
            if (countOne != 0) res += countOne == 1 ? 1 : 2;
            return res;
        }
    }
}
