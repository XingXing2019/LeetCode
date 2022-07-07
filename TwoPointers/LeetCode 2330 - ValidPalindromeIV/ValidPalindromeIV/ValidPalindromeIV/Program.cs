using System;

namespace ValidPalindromeIV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool MakePalindrome(string s)
        {
            int li = 0, hi = s.Length - 1, count = 0;
            while (li < hi)
            {
                if (s[li] != s[hi])
                    count++;
                li++;
                hi--;
            }
            return count <= 2;
        }
    }
}
