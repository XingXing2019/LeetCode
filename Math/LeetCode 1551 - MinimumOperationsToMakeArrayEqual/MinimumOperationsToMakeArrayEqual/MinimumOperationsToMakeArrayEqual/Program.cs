using System;

namespace MinimumOperationsToMakeArrayEqual
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            Console.WriteLine(MinOperations(n));
        }
        static int MinOperations(int n)
        {
            int target = (1 + 2 * (n - 1) + 1) / 2;
            int len = n % 2 == 0 ? n / 2 - 1 : n / 2;
            var res = 0;
            for (int i = 0; i <= len; i++)
                res += target - (2 * i + 1);
            return res;
        }
    }
}
