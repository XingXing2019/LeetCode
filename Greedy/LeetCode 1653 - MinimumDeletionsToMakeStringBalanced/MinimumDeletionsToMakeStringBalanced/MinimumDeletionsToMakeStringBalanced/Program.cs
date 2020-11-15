using System;

namespace MinimumDeletionsToMakeStringBalanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "aababbab";
            Console.WriteLine(MinimumDeletions(s));
        }
        static int MinimumDeletions(string s)
        {
            var leftB = new int[s.Length];
            var rightA = new int[s.Length];
            int a = 0, b = 0;
            for (int i = 0; i < s.Length; i++)
            {
                leftB[i] = b;
                if (s[i] == 'b')
                    b++;
            }
            for (int i = s.Length - 1; i >= 0; i--)
            {
                rightA[i] = a;
                if (s[i] == 'a')
                    a++;
            }
            var res = int.MaxValue;
            for (int i = 0; i < s.Length; i++)
                res = Math.Min(res, leftB[i] + rightA[i]);
            return res;
        }
    }
}
