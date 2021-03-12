using System;
using System.Linq;

namespace CheckIfAStringContainsAllBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "00110110";
            int k = 2;
            Console.WriteLine(HasAllCodes(s, k));
        }
        static bool HasAllCodes(string s, int k)
        {
            if (k > s.Length) return false;
            int num = 0;
            for (int i = 0; i < k; i++)
                num = num * 2 + 1;
            var check = new bool[num + 1];
            var str = s.Substring(0, k);
            int tempNum = 0;
            foreach (var c in str)
                tempNum = tempNum * 2 + (c - '0');
            if (tempNum <= num)
                check[tempNum] = true;
            var pow = (int) Math.Pow(2, k - 1);
            for (int i = 1; i <= s.Length - k; i++)
            {
                tempNum -= (s[i - 1] - '0') * pow;
                tempNum = tempNum * 2 + (s[i + k - 1] - '0');
                if (tempNum <= num)
                    check[tempNum] = true;
            }
            return check.All(x => x);
        }
    }
}
