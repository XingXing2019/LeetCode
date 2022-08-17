//创建string数组morse，按a-z顺序存储摩斯码。创建字典counts用于存储独一的摩斯码串。
//遍历字符串数组words，得到数组中的每一个单词word。创建字符串code用于存储摩斯码串。
//遍历word中每一个字母，找出其对应的摩斯码存入code。
//检查counts字典中是否存在现有的摩斯码串code，如不存在，则将其加入字典。
//最后返回counts字典中键值对的个数。
using System;
using System.Collections.Generic;

namespace UniqueMorseCodeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = {"rwjje","aittjje","auyyn","lqtktn","lmjwn"};
            Console.WriteLine(UniqueMorseRepresentations(words));
        }
        static int UniqueMorseRepresentations(string[] words)
        {
            string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (var word in words)
            {
                string code = "";
                for (int i = 0; i < word.Length; i++)
                {
                    code += morse[word[i] - 'a'];
                }
                if (!counts.ContainsKey(code))
                    counts.Add(code, 1);
            }
            return counts.Count;
        }
    }
}
