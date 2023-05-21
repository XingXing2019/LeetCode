using System;
using System.Text;

namespace LexicographicallySmallestPalindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string MakeSmallestPalindrome(string s)
        {
            var sb = new StringBuilder(s);
            int li = 0, hi = sb.Length - 1;
            while (li < hi)
            {
                if (sb[li] < sb[hi])
                    sb[hi--] = sb[li++];
                else
                    sb[li++] = sb[hi--];
            }
            return sb.ToString();
        }
    }
}
