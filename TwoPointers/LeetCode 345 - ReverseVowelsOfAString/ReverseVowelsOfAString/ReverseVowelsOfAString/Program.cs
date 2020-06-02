//创建vowels和pos列表记录元音字母和其位置。创建StringBuilder型res记录结果。
//遍历字符串，如果遇到元音字母就将其和其位置存入vowels和pos列表，并在res中其相应位置加上一个符号占位。
//创建vowelPointer指针帮助遍历vowel列表，初始值指向vowels最后一个元素。遍历pos列表，在相应位置替换vowelPointer指向的元音字母，替换后时vowelP向前移动一位。
using System;
using System.Text;
using System.Collections.Generic;

namespace ReverseVowelsOfAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "@abo";
            Console.WriteLine(ReverseVowels(s));
        }
        static string ReverseVowels(string s)
        {
            List<char> vowels = new List<char>();
            List<int> pos = new List<int>();
            StringBuilder res = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a' || s[i] == 'A' || s[i] == 'e' || s[i] == 'E' || s[i] == 'i' || s[i] == 'I' || s[i] == 'o' || s[i] == 'O' || s[i] == 'u' || s[i] == 'U')
                {
                    vowels.Add(s[i]);
                    pos.Add(i);
                    res.Append('@');
                }
                else
                    res.Append(s[i]);
            }
            int vowelPointer = vowels.Count - 1;
            for (int i = 0; i < pos.Count; i++)
            {
                res[pos[i]] = vowels[vowelPointer];
                vowelPointer--;
            }
            return res.ToString();
        }
    }
}
