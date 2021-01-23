using System;

namespace PalindromeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 121;
            Console.WriteLine(IsPalindrome(x));
        }
        static bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            int tem = x;
            int record = 0;
            while (tem != 0)
            {
                record *= 10;
                record += tem % 10;
                tem /= 10;
            }
            return record == x;
        }
    }
}
