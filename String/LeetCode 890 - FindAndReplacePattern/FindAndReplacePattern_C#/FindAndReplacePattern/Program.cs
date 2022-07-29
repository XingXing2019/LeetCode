//遍历words获得每一个word，如果该word字符数与pattern长度不符，可直接跳过该word。否则遍历word逐个字符检查。
//创建字典储存word和pattern中的字符对。创建长度为128的数组用于标记pattern中的字符。建立pos指针用于遍历pattern。建立isVaild代表该word是否符合条件，将其初始值设为true。
//遍历word中每个字符，首先检查当前字符知否在字典中。
//如不在，并且其在pattern中对应的字符已经被标记过, 证明其已被其他字符使用，则将isVaild设为false。否则标记pattern中该字符。并将该字符对加入字典。
//如果word中的字符已经在字典中，则检查该字符对应得字符是否为pattern中pos所指向的字符，如不是则将isVaild设为true。
//完成以上判断后将pos加一。
//如此时isVaild仍为true，则将该word加入res。
using System;
using System.Collections.Generic;

namespace FindAndReplacePattern
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        public IList<string> FindAndReplacePattern(string[] words, string pattern)
        {
            if (pattern == "")
                return words;
            List<string> res = new List<string>();
            foreach (var word in words)
            {
                if (word.Length != pattern.Length)
                    continue;
                Dictionary<char, char> map = new Dictionary<char, char>();
                int[] charMap = new int[128];
                int pos = 0;
                bool isVaild = true;
                for (int i = 0; i < word.Length; i++)
                {
                    char current = word[i];
                    if (!map.ContainsKey(current))
                    {
                        if (charMap[pattern[pos]] != 0)
                            isVaild = false;
                        charMap[pattern[pos]]++;
                        map.Add(current, pattern[pos]);
                    }
                    else
                    {
                        if (map[current] != pattern[pos])
                        isVaild = false; 
                    }
                    pos++;
                }
                if(isVaild)
                    res.Add(word);
            }
            return res;
        }
    }
}
