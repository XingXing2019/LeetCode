
using System;
using System.Text;

namespace AddingSpacesToAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string AddSpaces(string s, int[] spaces)
        {
            var res = new StringBuilder();
            int p1 = 0, p2 = 0;
            while (p1 < s.Length && p2 < spaces.Length)
            {
                if (p1 == spaces[p2])
                {
                    p2++;
                    res.Append(" ");
                }
                else
                    res.Append(s[p1++]);
            }
            return res + s.Substring(p1);
        }
    }
}
