using System;
using System.Collections.Generic;

namespace IntegerToEnglishWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 1000000;
            Console.WriteLine(NumberToWords(num));
        }

        public static string NumberToWords(int num)
        {
            if (num == 0) return "Zero";
            var res = "";
            string[] units = { "", "Thousand", "Million", "Billion" };
            var index = 0;
            var unitDict = new Dictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" },
                { 3, "Three" },
                { 4, "Four" },
                { 5, "Five" },
                { 6, "Six" },
                { 7, "Seven" },
                { 8, "Eight" },
                { 9, "Nine" },
                { 0, "" },
            };
            var decadeDict = new Dictionary<int, string>
            {
                { 2, "Twenty" },
                { 3, "Thirty" },
                { 4, "Forty" },
                { 5, "Fifty" },
                { 6, "Sixty" },
                { 7, "Seventy" },
                { 8, "Eighty" },
                { 9, "Ninety" },
            };
            var teenDict = new Dictionary<int, string>
            {
                { 11, "Eleven" },
                { 12, "Twelve" },
                { 13, "Thirteen" },
                { 14, "Fourteen" },
                { 15, "Fifteen" },
                { 16, "Sixteen" },
                { 17, "Seventeen" },
                { 18, "Eighteen" },
                { 19, "Nineteen" },
            };
            while (num != 0)
            {
                int unit = num % 10, decade = num / 10 % 10, hundred = num / 100 % 10;
                num /= 1000;
                res = $"{units[index++]} {res}";
                if (decade * 10 + unit < 10)
                    res = $"{unitDict[unit]} {res}";
                else if (decade * 10 + unit == 10)
                    res = $"Ten {res}";
                else if (decade * 10 + unit < 20)
                    res = $"{teenDict[decade * 10 + unit]} {res}";
                else
                    res = $"{decadeDict[decade]} {unitDict[unit]} {res}";
                if (hundred != 0)
                    res = $"{unitDict[hundred]} Hundred {res}";
            }
            var parts = res.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var words = new List<string>();
            for (int i = parts.Length - 1; i >= 0; i--)
            {
                if (parts[i] != "Thousand" && parts[i] != "Million")
                    words.Add(parts[i]);
                else if (parts[i] == "Thousand" && parts[i - 1] != "Million")
                    words.Add(parts[i]);
                else if (parts[i] == "Million" && parts[i - 1] != "Billion")
                    words.Add(parts[i]);
            }
            words.Reverse();
            return string.Join(' ', words);
        }
    }
}
