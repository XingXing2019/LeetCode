using System;
using System.Text;

namespace BreakAPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string BreakPalindrome(string palindrome)
        {
            if (palindrome.Length == 1)
                return "";
            var str = new StringBuilder(palindrome);
            int p1 = 0, p2 = str.Length - 1;
            while (p1 < p2)
            {
                if (str[p1] != 'a')
                {
                    str[p1] = 'a';
                    return str.ToString();
                }

                p1++;
                p2--;
            }
            str[^1] = 'b';
            return str.ToString();
        }
    }
}
