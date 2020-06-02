//创建unique列表接收独一的奇数位和偶数位字母组成的字符串。
//遍历A中的每一个单词。创建tem数组，长度设为52，代表奇数位和偶数位都各有26种可能的字母。
//遍历当前单词，将奇数位和偶数位相应的字母记录入tem。
//创建temStr字符串，用i指针遍历tem，如果i所代表的的字母个数不为0，则将i和该字母个数记入temStr。
//如果unique中不存在temStr，则将temStr加入unique。最后返回unique中元素的个数。
using System;
using System.Collections.Generic;

namespace GroupsOfSpecialEquivalentStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] A = new string[] { "abcd", "cdab", "cbad", "xyzz", "zzxy", "zzyx" };
            Console.WriteLine(NumSpecialEquivGroups(A));
        }
        static int NumSpecialEquivGroups(string[] A)
        {
            List<string> unique = new List<string>();
            foreach (var word in A)
            {
                int[] tem = new int[52];
                for (int i = 0; i < word.Length; i++)
                {
                    if (i % 2 != 0)
                        tem[word[i] - 'a']++;
                    else
                        tem[word[i] - 'a' + 26]++;
                }
                string temStr = "";
                for (int i = 0; i < tem.Length; i++)
                {
                    if (tem[i] != 0)
                        temStr += i.ToString() + tem[i].ToString();
                }
                if (!unique.Contains(temStr))
                    unique.Add(temStr);
            }
            return unique.Count;
        }
    }
}
