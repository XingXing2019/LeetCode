using System;
using System.Linq;
using System.Text;

namespace LargestPalindromicNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string LargestPalindromic(string num)
        {
            if (num.All(x => x == '0')) return "0";
            var digits = new int[10];
            foreach (var d in num)
                digits[d - '0']++;
            var before = new StringBuilder();
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] <= 1) continue;
                before.Append(new string((char) (i + '0'), digits[i] / 2));
                digits[i] -= digits[i] / 2 * 2;
            }
            var mid = -1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] != 0)
                {
                    mid = i;
                    break;
                }
            }
            var after = new StringBuilder();
            for (int i = before.Length - 1; i >= 0; i--)
                after.Append(before[i]);
            var res = mid == -1 ? $"{before}{after}" : $"{before}{(char)(mid + '0')}{after}";
            return res.Trim('0');
        }
    }
}
