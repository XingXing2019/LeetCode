//统计secret和guess中每个数字出现的位置，将结果记录人sDict和gDict两个字典。
//遍历gDict，如果secret中有当前数字，则统计有多少个数字具有相同的位置，记录如temBCount，则对于该数字的cCount就是当前数字在sDict和gDict中较小的出现次数减去temBCount。将其加入整体cCount，将temBCount加入整体bCount。
//按照要求输出res。
using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            string secret = "1807";
            string guess = "7810";
            Console.WriteLine(GetHint(secret, guess));
        }
        static string GetHint_Array(string secret, string guess)
        {
            var digits = new int[10];
            int bulls = 0, cows = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                    bulls++;
                digits[secret[i] - '0']++;
            }
            for (int i = 0; i < guess.Length; i++)
            {
                if (digits[guess[i] - '0'] > 0)
                    cows++;
                digits[guess[i] - '0']--;
            }
            return $"{bulls}A{cows - bulls}B";
        }
        static string GetHint_Dictionary(string secret, string guess)
        {
            Dictionary<char, Dictionary<int, int>> sDict = new Dictionary<char, Dictionary<int, int>>();
            Dictionary<char, Dictionary<int, int>> gDict = new Dictionary<char, Dictionary<int, int>>();
            for (int i = 0; i < secret.Length; i++)
            {
                if (!sDict.ContainsKey(secret[i]))
                    sDict[secret[i]] = new Dictionary<int, int>() { { i, 1 } };
                else
                    sDict[secret[i]].Add(i, 1);
            }
            for (int i = 0; i < guess.Length; i++)
            {
                if (!gDict.ContainsKey(guess[i]))
                    gDict[guess[i]] = new Dictionary<int, int>() { { i, 1 } };
                else
                    gDict[guess[i]].Add(i, 1);
            }
            string res = "";
            int bCount = 0, cCount = 0;
            foreach (var kv in gDict)
            {
                int temBCount = 0;
                if (sDict.ContainsKey(kv.Key))
                {
                    foreach (var index in kv.Value)
                    {
                        if (sDict[kv.Key].ContainsKey(index.Key))
                            temBCount++;
                    }
                    cCount += Math.Min(sDict[kv.Key].Count, kv.Value.Count) - temBCount;
                    bCount += temBCount;
                }
            }
            res = bCount + "A" + cCount + "B";
            return res;
        }
    }
}
