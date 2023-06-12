using System;
using System.Text;

namespace LexicographicallySmallestString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "a";
            Console.WriteLine(SmallestString(s));
        }

        public static string SmallestString(string s)
        {
            var index = 0;
            var seen = false;
            var res = new StringBuilder();
            while (index < s.Length && s[index] == 'a')
                res.Append(s[index++]);
            if (index == s.Length)
                res[^1] = 'z';
            for (int i = index; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    res.Append(s[i]);
                    if (i != 0)
                        seen = true;
                }
                else
                {
                    var l = seen ? s[i] : (char)(s[i] - 1);
                    res.Append(l);
                }
            }
            return res.ToString();
        }
    }
}
