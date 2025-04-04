﻿using System;

namespace SmallestStringWithAGivenNumericValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5, k = 73;
            Console.WriteLine(GetSmallestString(n, k));
        }
        static string GetSmallestString(int n, int k)
        {
            var count = (k - n) / 25;
            var left = n - count - 1 > 0 ? new string('a', n - count - 1) : "";
            var right = new string('z', count);
            k -= left.Length + 26 * right.Length;
            var mid = k - 1 < 0 ? "" : ((char) (k - 1 + 'a')).ToString();
            return left + mid + right;
        }
    }
}
