using System;

namespace MinimumLengthOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MinimumLength(string s)
        {
            int li = 0, hi = s.Length - 1;
            while (li < hi && s[li] == s[hi])
            {
                while (li < hi && s[li] == s[li + 1])
                    li++;
                while (li < hi && s[hi] == s[hi - 1])
                    hi--;
                li++;
                hi--;
            }
            return hi >= li ? hi - li + 1 : 0;
        }
    }
}
