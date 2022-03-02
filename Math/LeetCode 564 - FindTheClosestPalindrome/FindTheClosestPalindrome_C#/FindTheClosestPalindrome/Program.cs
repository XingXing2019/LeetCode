using System;
using System.Linq;
using System.Text;

namespace FindTheClosestPalindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = "7722";
            Console.WriteLine(NearestPalindromic(n));
        }

        public static string NearestPalindromic(string n)
        {
            var num = long.Parse(n);
            if (n.Length == 1 || IsPowTen(num)) return $"{num - 1}";
            if (num == 11) return "9";
            if (n.All(x => x == '9')) return $"{num + 2}";
            var half = long.Parse(n.Substring(0, (int)Math.Ceiling((double)n.Length / 2)));
            var minus = half - 1;
            var plus = half + 1;
            long[] candidates = { half, minus, plus };
            for (int i = 0; i < candidates.Length; i++)
                candidates[i] = MakePalindrome(candidates[i], n.Length % 2 == 0);
            candidates = candidates.Where(x => x != num).OrderBy(x => Math.Abs(x - num)).ThenBy(x => x).ToArray();
            return candidates[0].ToString();
        }

        private static bool IsPowTen(long num)
        {
            while (num % 10 == 0)
                num /= 10;
            return num == 1;
        }

        private static long MakePalindrome(long num, bool isEven)
        {
            var str = num.ToString();
            var res = new StringBuilder(str);
            var index = str.All(x => x == '9') || isEven ? str.Length - 1 : str.Length - 2;
            while (index >= 0)
                res.Append(str[index--]);
            return long.Parse(res.ToString());
        }
    }
}
