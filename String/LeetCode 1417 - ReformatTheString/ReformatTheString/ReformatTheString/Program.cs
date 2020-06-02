using System;
using System.Collections.Generic;

namespace ReformatTheString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string Reformat(string s)
        {
            var digits = new List<char>();
            var letters = new List<char>();
            foreach (var c in s)
            {
                if (char.IsDigit(c))
                    digits.Add(c);
                else
                    letters.Add(c);
            }
            var res = "";
            if (digits.Count != letters.Count && digits.Count != letters.Count + 1 && digits.Count != letters.Count - 1)
                return res;
            if (digits.Count > letters.Count)
            {
                for (int i = 0; i < letters.Count; i++)
                {
                    res += digits[i];
                    res += letters[i];
                }
            }
            else
            {
                for (int i = 0; i < digits.Count; i++)
                {
                    res += letters[i];
                    res += digits[i];
                }
            }
            if (digits.Count == letters.Count)
                return res;
            res += digits.Count > letters.Count ? digits[^1] : letters[^1];
            return res;
        }
    }
}
