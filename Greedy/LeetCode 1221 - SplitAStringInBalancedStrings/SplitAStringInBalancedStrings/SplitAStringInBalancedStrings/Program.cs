//使用贪心算法。创建两个计数器记录L和R的数量。遍历数组，记录L和R的个数，当两个计数器相同时，则使res加一，并将计数器归零。
using System;

namespace SplitAStringInBalancedStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int BalancedStringSplit(string s)
        {
            int countL = 0;
            int countR = 0;
            int res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'L')
                    countL++;
                else
                    countR++;
                if (countL == countR)
                    res++;
            }
            return res;
        }
    }
}
