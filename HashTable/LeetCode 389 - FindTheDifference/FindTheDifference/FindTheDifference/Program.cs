//创建一个长度为26的数组记录字母，遍历t将字母记入数组，在遍历s将字母删除，最后剩下的就是结果。
using System;

namespace FindTheDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            string t = "e";
            Console.WriteLine(FindTheDifference(s, t));
        }
        static char FindTheDifference(string s, string t)
        {
            int res = 0;
            int[] record = new int[26];
            for (int i = 0; i < t.Length; i++)
                record[t[i] - 'a']++;
            for (int i = 0; i < s.Length; i++)
                record[s[i] - 'a']--;
            for (int i = 0; i < record.Length; i++)
                if (record[i] != 0)
                    res = i + 97;
            return (char)res;
        }
    }
}
