//先将A和B转化为单词数组。主要如果A或B长度为空要转化为空数组。创建字典记录符合条件的单词。
//遍历A和B，如果当前单词不在字典中，则将当前单词加入字典，value设为true。如果已经在字典中，则将该单词在字典中value设为false。
//最后返回字典中value为true的单子，可以用linq语句。
using System;
using System.Collections.Generic;
using System.Linq;

namespace UncommonWordsFromTwoSentences
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "";
            string B = "this apple is sour";
            Console.WriteLine(UncommonFromSentences(A, B));
        }
        static string[] UncommonFromSentences(string A, string B)
        {
            string[] arrA = A.Length == 0 ? new string[0] : A.Split(" ");
            string[] arrB = B.Length == 0 ? new string[0] : B.Split(" ");
            var dict = new Dictionary<string, bool>();
            foreach (var word in arrA)
            {
                if (!dict.ContainsKey(word))
                    dict[word] = true;
                else
                    dict[word] = false;
            } 
            foreach (var word in arrB)
            {
                if (!dict.ContainsKey(word))
                    dict[word] = true;
                else
                    dict[word] = false;
            }
            return dict.Where(w => w.Value).Select(w => w.Key).ToArray();
        }
    }
}
