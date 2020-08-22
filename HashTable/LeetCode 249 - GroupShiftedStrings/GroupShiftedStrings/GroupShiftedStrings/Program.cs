using System;
using System.Collections.Generic;

namespace GroupShiftedStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = {"abc", "bcd", "acef", "xyz", "az", "ba", "a", "z"};
            Console.WriteLine(GroupStrings(strings));
        }
        static IList<IList<string>> GroupStrings(string[] strings)
        {
            var dict = new Dictionary<string, List<string>>();
            foreach (var str in strings)
            {
                var code = "";
                if (str.Length != 1)
                {
                    for (int i = 1; i < str.Length; i++)
                    {
                        var temp = str[i] - str[i - 1];
                        if (temp < 0)
                            temp += 26;
                        code += temp + ":";
                    }
                }
                if(!dict.ContainsKey(code))
                    dict[code] = new List<string>();
                dict[code].Add(str);
            }
            var res = new List<IList<string>>();
            foreach (var kv in dict)
                res.Add(kv.Value);
            return res;
        }
    }
}
