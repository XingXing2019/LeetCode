using System;

namespace SplitTwoStringsToMakePalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "pvhmupgqeltozftlmfjjde", b = "yjgpzbezspnnpszebzmhvp";
            Console.WriteLine(CheckPalindromeFormation(a, b));
        }
        static bool CheckPalindromeFormation(string a, string b)
        {
            return Check(a, b) || Check(b, a);
        }

        static bool CheckPalindrome(string str, int li, int hi)
        {
            while (li < hi)
            {
                if (str[li++] != str[hi--])
                    return false;
            }
            return true;
        }

        static bool Check(string a, string b)
        {
            int li = 0, hi = a.Length - 1;
            while (li < hi && a[li] == b[hi])
            {
                li++;
                hi--;
            }
            return CheckPalindrome(a, li, hi) || CheckPalindrome(b, li, hi);
        }
    }
}
