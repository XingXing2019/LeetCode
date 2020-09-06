using System;
using System.Text;

namespace ReplaceAll
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "wz???a??n";
            Console.WriteLine(ModifyString(s));
        }
        static string ModifyString(string s)
        {
            var res = new StringBuilder(s);
            for (int i = 0; i < res.Length; i++)
            {
                if (s[i] == '?')
                {
                    var before = i == 0 ? '*' : res[i - 1];
                    var after = i == s.Length - 1 ? '*' : res[i + 1];
                    res[i] = before == 'a' || after == 'a'
                        ? (char)(Math.Min(before, after) + 1)
                        : (char)(Math.Min(before, after) - 1);
                    res[i] = res[i] == '?' ? (char)(res[i] - 2) : res[i];
                }
            }
            return res.ToString();
        }
    }
}
