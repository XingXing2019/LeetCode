using System;

namespace LongestNiceSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "dDzeE";
            Console.WriteLine(LongestNiceSubstring(s));
        }
        public static string LongestNiceSubstring(string s)
        {
            var res = "";
            for (int i = 0; i < s.Length; i++)
            {
                var lowerCase = new int[26];
                var upperCase = new int[26];
                for (int j = i; j < s.Length; j++)
                {
                    if (char.IsUpper(s[j])) upperCase[s[j] - 'A']++;
                    else lowerCase[s[j] - 'a']++;
                    if (Check(lowerCase, upperCase) && j - i + 1 > res.Length)
                        res = s.Substring(i, j - i + 1);
                }
            }
            return res;
        }

        public static bool Check(int[] lowerCase, int[] upperCase)
        {
            for (int i = 0; i < lowerCase.Length; i++)
            {
                if ((lowerCase[i] != 0 || upperCase[i] != 0) && lowerCase[i] * upperCase[i] == 0)
                    return false;
            }
            return true;
        }
    }
}
