using System;
using System.Text;

namespace StrictlyPalindromicNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsStrictlyPalindromic(int n)
        {
            for (int i = 2; i <= n - 2; i++)
            {
                if (IsPalindromic(GetBase(n, i))) continue;
                return false;
            }
            return true;
        }

        public string GetBase(int num, int baseNum)
        {
            var res = new StringBuilder();
            while (num != 0)
            {
                res.Append(num % baseNum);
                num /= baseNum;
            }
            return res.ToString();
        }

        public bool IsPalindromic(string num)
        {
            int li = 0, hi = num.Length - 1;
            while (li < hi)
            {
                if (num[li++] == num[hi--]) continue;
                return false;
            }
            return true;
        }
    }
}
