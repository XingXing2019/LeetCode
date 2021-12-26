
using System;
using System.Linq.Expressions;

namespace CheckIfAParenthesesStringCanBeValid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = ")(", locked = "00";
            Console.WriteLine(CanBeValid(s, locked));
        }

        public static bool CanBeValid(string s, string locked)
        {
            if (s.Length % 2 != 0) return false;
            int unpaired = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ')')
                    unpaired--;
                else
                {
                    unpaired += locked[i] == '0' ? -1 : 1;
                    if (unpaired > 0)
                        return false;
                }
            }
            unpaired = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] != '(')
                    unpaired--;
                else
                {
                    unpaired += locked[i] == '0' ? -1 : 1;
                    if (unpaired > 0)
                        return false;
                }
            }
            return true;
        }
    }
}
