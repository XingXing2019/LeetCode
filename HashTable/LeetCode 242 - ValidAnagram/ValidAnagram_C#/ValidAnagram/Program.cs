//创建record数组。遍历s，将s中的字母在record中相应位置加一。再遍历t将t中字母在record中相应位置减一。最后检查record的每个位置是否为0。
//需要特别判断长度小于等于1的情况，如果s和t的长度小于等于1，则直接返回s是否等于t。
using System;

namespace ValidAnagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool IsAnagram(string s, string t)
        {
            if (s.Length <= 1 && t.Length <= 1)
                return s == t;           
            int[] record = new int[26];
            foreach (var letter in s)
                record[letter - 'a']++;
            foreach (var letter in t)
                record[letter - 'a']--;
            foreach (var r in record)
                if (r != 0)
                    return false;
            return true;
        }
    }
}
