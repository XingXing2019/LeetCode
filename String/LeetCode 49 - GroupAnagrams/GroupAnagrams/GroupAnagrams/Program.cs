//创建hashMap字典，key为string，value为List<string>。用于存储相同字符的单词。
//遍历strs中每一个单词word，把他们转化成CharArray后进行排序，再转化成字符串。
//如果这时字典中不存在key为该字符串，创建该字符串的key，将对应的value设为new List<string>，再将此时遍历到的word的添加到List中、
//如果这时字典中已存在key为该字符串，则直接将遍历到的word添加到List中。
//比那里结束后设置List<string>的Array接收结果。其长度设为字典中键值对的个数。
using System;
using System.Collections.Generic;

namespace GroupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };
            GroupAnagrams(strs);
        }
        static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var hashMap = new Dictionary<string, List<string>>();
            foreach (var word in strs)
            {
                var tem = word.ToCharArray();
                Array.Sort(tem);
                String str = new string(tem);
                if (!hashMap.ContainsKey(str))
                {
                    hashMap.Add(str, new List<string>());
                    hashMap[str].Add(word);
                }
                else
                    hashMap[str].Add(word);
            }
            var res = new List<string>[hashMap.Count];
            Console.WriteLine(res[0]);
            int i = 0;
            foreach (var words in hashMap)
            {
                res[i] = words.Value;
                i++;
            }
            return res;
        }
    }
}
