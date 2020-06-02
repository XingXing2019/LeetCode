//思路为先将第一个单词设为模板。用每个单词与模板比较，如果共有前缀缩小，则替换模板。最后省下的模板就是结果。
//创建model，初始值设为字符串组的第一个字符串。
//从字符串组第二个元素开始遍历。创建tem存储现有的最长共有前缀。
//遍历当前单词，注意需要保证index i不要超出当前单词和model的边界。
//如果遍历到的字母和model中相同位置的字母相同，则将其存入tem。一旦发现不同则停止遍历。
//如果tem的长度小于model的长度，则用tem替换model。最后返回model。
using System;

namespace LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strs = { "dog", "racecar", "car" };
            Console.WriteLine(LongestCommonPrefix(strs));
        }
        static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";
            string model = strs[0];
            foreach (var word in strs)
            {
                string tem = "";
                for (int i = 0; i < word.Length && i < model.Length; i++)
                {
                    if (word[i] == model[i])
                        tem += word[i];
                    else
                        break;
                }
                model = tem;
            }
            return model;
        }
    }
}
