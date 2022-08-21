using System;
using System.Text;

namespace TimeNeededToRearrangeABinaryString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "0110101";
            Console.WriteLine(SecondsToRemoveOccurrences(s));
        }

        public static int SecondsToRemoveOccurrences(string s)
        {
            var res = 0;
            var before = new StringBuilder(s);
            while (CanChange(before, out var after))
            {
                res++;
                before = after;
            }
            return res;
        }

        public static bool CanChange(StringBuilder before, out StringBuilder after)
        {
            after = new StringBuilder();
            var canChange = false;
            for (int i = 0; i < before.Length; i++)
            {
                if (before[i] == '0')
                    after.Append('0');
                else
                {
                    if (after.Length != 0 && before[i - 1] == '0')
                    {
                        after[^1] = '1';
                        after.Append('0');
                        canChange = true;
                    }
                    else
                        after.Append('1');
                }
            }
            return canChange;
        }
    }
}
