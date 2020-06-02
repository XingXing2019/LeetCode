//暴力检查A和B中每个单词的合法性会超时。思路为先统计B中每个单词中每个字母的出现频率，将其记录入一个数组record。对于每个字母取其频率的最大值。
//再遍历A中的每个单词，统计其中每个字母出现的频率，如果频率不小于record中对应字母的频率，则证明该单词合法，将其加入res。
using System;
using System.Collections.Generic;

namespace WordSubsets
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static IList<string> WordSubsets(string[] A, string[] B)
        {
            int[] record = new int[26];
            for (int i = 0; i < record.Length; i++)
            {
                int max = int.MinValue;
                foreach (var b in B)
                {
                    int tem = 0;
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (b[j] - 'a' == i)
                            tem++;
                    }
                    max = Math.Max(max, tem);
                }
                record[i] = max;
            }
            var res = new List<string>();
            foreach (var a in A)
            {
                bool valid = true;
                for (int i = 0; i < 26; i++)
                {
                    int count = 0;
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (a[j] - 'a' == i)
                            count++;
                    }
                    if (count < record[i])
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                    res.Add(a);
            }
            return res;
        }
        
    }
}
