//设立word用以临时存储单词。建立Dictionary保存word和其pattern中的字母代码。设立pos代表当前pattern位置。建立charMap[128]，用于标记pattern中字母是否出现过。
//人为在str后面加上一个空格。遍历str计算空格个数代表word个数，如空格个数与pattern长度不等，直接返回false。
//遍历str截取word，当遇到空格时证明word截取完毕。检查Dictionary中是否包含该word，如不包含,检查其对应字母是否已被标记，如已标记证明该字母已被其他word使用，返回false。
//如未被标记则将word和其对应字母加入Dictionary。同时将该字母标记。
//当获取word后发现Dictionary中已经包含该word，检查与之对应的字母是否为Dictionary中的字母，如不是则返回false。
//此轮判断结束后清空word，并使pos加一。
//完成遍历后如未出发false，则返回true。
using System;
using System.Collections.Generic;

namespace WordPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "abb";
            string str = "dog cat cat dog";
            Console.WriteLine(WordPattern(pattern, str));
        }
        static bool WordPattern(string pattern, string str)
        {
            Dictionary<string, char> strCharMap = new Dictionary<string, char>();
            int[] charMap = new int[128];
            string word = "";
            int pos = 0;
            str = str.Insert(str.Length, " ");
            int spcNum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    spcNum++;
            }
            if (spcNum != pattern.Length)
                return false;

            for (int i = 0; i < str.Length; i++)
            {
                word += str[i];
                if (str[i] == ' ')
                {
                    if (!strCharMap.ContainsKey(word))
                    {
                        if (charMap[pattern[pos]] != 0)
                            return false;
                        strCharMap.Add(word, pattern[pos]);
                        charMap[pattern[pos]]++;
                    }
                    else
                    {
                        if (strCharMap[word] != pattern[pos])
                            return false;
                    }
                    word = "";
                    pos++;
                }
            }
            return true;
        }
    }
}
