using System;
using System.Text;

namespace CalculateDigitSumOfAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "1234";
            int k = 2;
            Console.WriteLine(DigitSum(s, k));
        }

        public static string DigitSum(string s, int k)
        {
            if (s.Length <= k) return s;
            var next = new StringBuilder();
            int sum = 0, count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                sum += s[i] - '0';
                count++;
                if (count != k) continue;
                next.Append(sum.ToString());
                count = 0;
                sum = 0;
            }
            if (count != 0) next.Append(sum.ToString());
            return DigitSum(next.ToString(), k);
        }
    }
}
