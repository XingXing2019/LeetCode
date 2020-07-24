using System;
using System.Collections.Generic;
using System.Text;

namespace FlipGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static IList<string> GeneratePossibleNextMoves(string s)
        {
            var res = new List<string>();
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1] && s[i] == '+')
                {
                    var temp = new StringBuilder(s);
                    temp[i] = '-';
                    temp[i - 1] = '-';
                    res.Add(temp.ToString());
                }
            }
            return res;
        }
    }
}
