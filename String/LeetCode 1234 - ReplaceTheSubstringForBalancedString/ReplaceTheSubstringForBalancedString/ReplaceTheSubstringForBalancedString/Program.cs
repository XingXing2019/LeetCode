using System;
using System.Collections.Generic;
using System.Linq;

namespace ReplaceTheSubstringForBalancedString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "QWER";
            Console.WriteLine(BalancedString(s));
        }
        static int BalancedString(string s)
        {
            var dict = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (!dict.ContainsKey(c))
                    dict[c] = 1;
                else
                    dict[c]++;
            }
            int quarter = s.Length / 4;
            if (dict.All(x => x.Value == quarter))
                return 0;
            int li = 0, hi = 0;
            int res = int.MaxValue;            
            dict[s[li]]--;
            while (hi < s.Length)
            {
                if (dict.All(x => x.Value <= quarter))
                {
                    res = Math.Min(res, hi - li + 1);
                    dict[s[li]]++;
                    li++;
                }
                else
                {
                    hi++;
                    if(hi >= s.Length)
                        break;
                    dict[s[hi]]--;
                }
            }
            return res;
        }
    }
}
