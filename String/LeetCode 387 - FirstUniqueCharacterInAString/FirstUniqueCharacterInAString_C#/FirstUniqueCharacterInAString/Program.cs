//创建index记录结果。创建charMap数组记录每个字母出现的次数，长度设为26。
//遍历字符串，将每个字母在charMap中所对应的位置加一。
//再次遍历字符串，如果当前字母在charMap所对应的位置的个数为1，则将index设为i，并停止遍历。
//最后返回index。
using System;
using System.Collections.Generic;

namespace FirstUniqueCharacterInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "aadadaad";
            Console.WriteLine(FirstUniqChar(s));

        }
        static int FirstUniqChar(string s)
        {
            int index = -1;
            int[] charMap = new int[26];
            for (int i = 0; i < s.Length; i++)
                charMap[s[i] - 'a']++;
            for (int i = 0; i < s.Length; i++)
            {
                if (charMap[s[i] - 'a'] == 1)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        static int FirstUniqChar2(string s)
        {
            if (s == "")
                return -1;
            Dictionary<char, int> letterMap = new Dictionary<char, int>();
            letterMap.Add(s[0], 0);
            for (int i = 1; i < s.Length; i++)
            {
                if (!letterMap.ContainsKey(s[i]))
                    letterMap.Add(s[i], i);
                else
                    letterMap[s[i]] = -1;
            }
            int index = int.MaxValue;
            foreach (var letter in letterMap)
            {
                if (letter.Value < index && letter.Value >= 0)
                    index = letter.Value;
            }
            if (index == int.MaxValue)
                index = -1;
            return index;
        }
        
    }
}
