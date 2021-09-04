using System;

namespace MaximumNestingDepth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxDepth(string s)
        {
            int left = 0, res = 0;
            foreach (var letter in s)
            {
                if (letter == '(')
                {
                    left++;
                    res = Math.Max(res, left);
                }
                else if (letter == ')')
                    left--;
            }
            return res;
        }
    }
}
