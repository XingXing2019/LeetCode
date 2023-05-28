using System;

namespace RemoveTrailingZerosFromAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string RemoveTrailingZeros(string num)
        {
            var res = "";
            var seenNum = false;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                if (num[i] == '0' && seenNum)
                {
                    res = num[i] + res;
                }
                else if (num[i] != '0')
                {
                    res = num[i] + res;
                    seenNum = true;
                }
            }
            return res;
        }
    }
}
