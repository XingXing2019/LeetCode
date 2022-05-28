using System;
using System.Linq;

namespace CheckIfNumberHasEqual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool DigitCount(string num)
        {
            var dict = num.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            for (int i = 0; i < num.Length; i++)
            {
                var letter = (char)(i + '0');
                if (dict.ContainsKey(letter) && dict[letter] != num[i] - '0')
                    return false;
                if (!dict.ContainsKey(letter) && num[i] - '0' != 0)
                    return false;
            }
            return true;
        }
    }
}
