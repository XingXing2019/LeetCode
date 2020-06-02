using System;
using System.Collections.Generic;
using System.Linq;

namespace SwapForLongestRepeatedCharacterSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "baabaaabbbabaabaab";
            Console.WriteLine(MaxRepOpt1(text));
        }
        static int MaxRepOpt1(string text)
        {
            var record = new List<int>[26];
            for (int i = 0; i < text.Length; i++)
            {
                if (record[text[i] - 'a'] == null)
                    record[text[i] - 'a'] = new List<int> { i };
                else
                    record[text[i] - 'a'].Add(i);
            }
            int res = 0;
            for (int i = 0; i < record.Length; i++)
                if (record[i] != null)
                    res = Math.Max(res, GetMaxLen(record[i]));
            return res;
        }
        static int GetMaxLen(List<int> index)
        {
            var list = new List<int[]>();
            int li = 0, hi = li + 1;
            while (hi < index.Count)
            {
                if (index[hi] == index[hi - 1] + 1)
                    hi++;
                else
                {
                    list.Add(new int[3] { index[li], index[hi - 1], hi - li });
                    li = hi;
                    hi++;
                }
            }
            list.Add(new int[3] { index[li], index[hi - 1], hi - li });
            int res = list[0][2];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i][0] == list[i - 1][1] + 2)
                {
                    if (list.Count > 2)
                        res = Math.Max(res, list[i][2] + list[i - 1][2] + 1);
                    else
                        res = Math.Max(res, list[i][2] + list[i - 1][2]);
                }
                else
                    res = Math.Max(res, Math.Max(list[i][2], list[i - 1][2]) + 1);
            }
            return res;
        }
    }
}
