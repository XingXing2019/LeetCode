//创建长度为n的数组接受结果。从1遍历到n，当i是15，5，3的倍数时将res[i - 1]设为相应的单词。否则将res[i - 1]设为i的字符串。
using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 15;
            Console.WriteLine(FizzBuzz(n));
        }
        static IList<string> FizzBuzz(int n)
        {
            string[] res = new string[n];
            if (n == 0)
                return res;
            for (int i = 1; i <= n; i++)
            {
                if (i % 15 == 0)
                    res[i - 1] = "FizzBuzz";
                else if (i % 5 == 0)
                    res[i - 1] = "Buzz";
                else if (i % 3 == 0)
                    res[i - 1] = "Fizz";
                else
                    res[i - 1] = i.ToString();
            }
            return res;
        }
    }
}
