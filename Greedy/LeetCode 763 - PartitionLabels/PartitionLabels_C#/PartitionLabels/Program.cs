//创建res列表接收结果，创建finalIndex数组记录每个字母最后一次出现的位置。
//遍历S字符串，将每个字母最后出现的位置记入finalIndex。
//创建maxFinal记录已经遍历过的元素中，最拥有的最靠后的finalIndex。创建mark指针用于辅助截取字符串。
//遍历字符串，如果当前元素最后出现的位置大于maxFinal，则替换maxFinal。
//如果当前遍历到的位置等于maxFinal，则证明之后不会再出现之前遍历过的元素，所以应该在此处截断字符串。并将长度记录入res
//并将mark移动到当前元素的下一个元素，准备下一次截断。
//最后返回res
using System;
using System.Collections.Generic;

namespace PartitionLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "caedbdedda";
            Console.WriteLine(PartitionLabels(S));
        }
        static IList<int> PartitionLabels(string S)
        {
            var res = new List<int>();
            var finalIndex = new int[26];
            for (int i = 0; i < S.Length; i++)
                finalIndex[S[i] - 'a'] = i;
            var maxIndex = 0;
            var mark = -1;
            for (int i = 0; i < S.Length; i++)
            {
                maxIndex = Math.Max(maxIndex, finalIndex[S[i] - 'a']);
                if (i == maxIndex)
                {
                    res.Add(i - mark);
                    mark = i;
                }
            }
            return res;
        }
    }
}
