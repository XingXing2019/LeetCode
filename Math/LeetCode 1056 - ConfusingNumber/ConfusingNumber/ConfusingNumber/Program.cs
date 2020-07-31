using System;
using System.Collections.Generic;

namespace ConfusingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 6;
            Console.WriteLine(ConfusingNumber(N));
        }
        static bool ConfusingNumber(int N)
        {
            var validNums = new Dictionary<int, int> {{0, 0}, {1, 1}, {6, 9}, {8, 8}, {9, 6}};
            int n = N, num = 0;
            while (N != 0)
            {
                if (!validNums.ContainsKey(N % 10))
                    return false;
                num = num * 10 + validNums[N % 10];
                N /= 10;
            }
            return num != n;
        }
    }
}
