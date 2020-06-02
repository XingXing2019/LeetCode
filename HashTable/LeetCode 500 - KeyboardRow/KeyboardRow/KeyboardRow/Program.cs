//创建CheckWords方法检查一个单词是否能用同一行字母构成。
//在主方法中创建count计数器，对words中每一个单词变成小写调用CheckWords方法，如果符合条件count加一。
//创建长度为count的数组记录结果。再次遍历words，将符合条件的word加入res。
using System;
using System.Collections.Generic;

namespace KeyboardRow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string[] FindWords(string[] words)
        {
            int count = 0;
            foreach (var word in words)
                if (CheckWords(word.ToLower()))
                    count++;
            string[] res = new string[count];
            int index = 0;
            foreach (var word in words)
                if (CheckWords(word.ToLower()))
                    res[index++] = word;
            return res;
        }
        static bool CheckWords(string word)
        {
            if (word == "")
                return true;
            var dict1 = new Dictionary<char, int>() { { 'q', 1 }, { 'w', 1 }, { 'e', 1 }, { 'r', 1 }, { 't', 1 }, { 'y', 1 }, { 'u', 1 }, { 'i', 1 }, { 'o', 1 }, { 'p', 1 } };
            var dict2 = new Dictionary<char, int>() { { 'a', 1 }, { 's', 1 }, { 'd', 1 }, { 'f', 1 }, { 'g', 1 }, { 'h', 1 }, { 'j', 1 }, { 'k', 1 }, { 'l', 1 } };
            var dict3 = new Dictionary<char, int>() { { 'z', 1 }, { 'x', 1 }, { 'c', 1 }, { 'v', 1 }, { 'b', 1 }, { 'n', 1 }, { 'm', 1 } };
            bool inDict1 = dict1.ContainsKey(word[0]);
            bool inDict2 = dict2.ContainsKey(word[0]);
            if (inDict1)
            {
                for (int i = 1; i < word.Length; i++)
                    if (!dict1.ContainsKey(word[i]))
                        return false;
                return true;
            }
            else if (inDict2)
            {
                for (int i = 1; i < word.Length; i++)
                    if (!dict2.ContainsKey(word[i]))
                        return false;
                return true;
            }
            else 
            {
                for (int i = 1; i < word.Length; i++)
                    if (!dict3.ContainsKey(word[i]))
                        return false;
                return true;
            }
        }

    }
}
