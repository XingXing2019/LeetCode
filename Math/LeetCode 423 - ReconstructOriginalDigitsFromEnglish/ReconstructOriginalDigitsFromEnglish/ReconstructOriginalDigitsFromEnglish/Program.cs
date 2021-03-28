using System;
using System.Linq;

namespace ReconstructOriginalDigitsFromEnglish
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "fviefuronineseventhreetwoeight";
            Console.WriteLine(OriginalDigits(s));
        }
        public static string OriginalDigits(string s)
        {
            var dict = new int[26];
            foreach (var l in s)
                dict[l - 'a']++;
            var nums = new int[10];
            string[] order = {"zero", "two", "four", "six", "eight", "one", "three", "five", "seven", "nine"};
            int[] numbers = {0, 2, 4, 6, 8, 1, 3, 5, 7, 9};
            char[] identifier = {'z', 'w', 'u', 'x', 'g', 'o', 't', 'f', 's', 'i'};
            for (int i = 0; i < order.Length; i++)
            {
                nums[numbers[i]] = dict[identifier[i] - 'a'];
                foreach (var l in order[i])
                    dict[l - 'a'] -= nums[numbers[i]];
            }
            var res = "";
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[i]; j++)
                    res += i.ToString();
            }
            return res;
        }
    }
}
