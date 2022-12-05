using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfDifferentIntegersInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "a123bc34d8ef34";
            Console.WriteLine(NumDifferentIntegers(word));
        }
        public static int NumDifferentIntegers(string word)
        {
            var separators = new char[26];
            for (int i = 0; i < separators.Length; i++)
                separators[i] = (char) (i + 'a');
            var nums = word.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var set = new HashSet<string>();
            foreach (var num in nums)
            {
                var temp = "";
                var isLeadingZero = true;
                foreach (var digit in num)
                {
                    if (digit != '0')
                    {
                        temp += digit;
                        isLeadingZero = false;
                    }
                    else if (!isLeadingZero)
                        temp += digit;
                }
                set.Add(temp);
            }
            return set.Count;
        }
    }
}
