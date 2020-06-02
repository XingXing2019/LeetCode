using System;
using System.Collections.Generic;
using System.Text;

namespace LetterCasePermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "a1b2";
            Console.WriteLine(LetterCasePermutation(S));
        }
        static IList<string> LetterCasePermutation(string S)
        {
            List<string> res = new List<string>();
            StringBuilder item = new StringBuilder(S);
            Generate(res, item, 0);
            return res;
        }

        static void Generate(List<string> res, StringBuilder item, int index)
        {
            if (index == item.Length)
            {
                res.Add(item.ToString());
                return;
            }
            Generate(res, item, index + 1);
            if (char.IsDigit(item[index])) return;
            item[index] = char.IsLower(item[index]) ? char.ToUpper(item[index]) : char.ToLower(item[index]);
            Generate(res, item, index + 1);
            item[index] = char.IsLower(item[index]) ? char.ToUpper(item[index]) : char.ToLower(item[index]);
        }
    }
}
