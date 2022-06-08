using System;
using System.Linq;

namespace RemovePalindromicSubsequences
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "ababa";
            Console.WriteLine(CheckPalindrome(s));
        }
        public int RemovePalindromeSub(string s)
        {
            if(s == "")
                return 0;
            return CheckPalindrome(s) ? 1 : 2;
        }

        static bool CheckPalindrome(string s)
        {
            int li = 0, hi = s.Length - 1;
            while (li < hi)
                if (s[li++] != s[hi--])
                    return false;
            return true;
        }

        public int RemovePalindromeSub_OneLine(string s)
        {
            return s == string.Join("", s.Reverse()) ? 1 : 2;
        }
    }
}
