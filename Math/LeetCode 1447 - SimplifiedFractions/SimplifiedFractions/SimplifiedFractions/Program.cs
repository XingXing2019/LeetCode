using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplifiedFractions
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            Console.WriteLine(SimplifiedFractions(n));
        }
        static IList<string> SimplifiedFractions(int n)
        {
            var res = new HashSet<string>();
            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    int maxCommonDivisor = GetMaxCommonDivisor(j, i);
                    string temp = $"{j / maxCommonDivisor}/{i / maxCommonDivisor}";
                    if (!res.Contains(temp))
                        res.Add(temp);
                }
            }
            return res.ToList();
        }

        static int GetMaxCommonDivisor(int num1, int num2)
        {
            for (int i = num1; i >= 1; i--)
                if (num1 % i == 0 && num2 % i == 0)
                    return i;
            return 1;
        }
    }
}
