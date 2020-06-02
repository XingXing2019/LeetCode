//将s以#号分割为字符串段的数组，由于数组的最后一个元素可能为空(s最后一位为#号的情况)，所以遍历到数组倒数第二位，按照要求将数字转化为字符存入res。
//如果s最后一位不为#号，还需将数组的最后一个元素进行处理并加入res。
using System;

namespace DecryptStringFromAlphabet
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "110#11#12#";
            Console.WriteLine(FreqAlphabets(s));
        }
        static string FreqAlphabets(string s)
        {
            var sections = s.Split('#');
            string res = "";
            for (int i = 0; i < sections.Length - 1; i++)
            {
                for (int j = 0; j < sections[i].Length - 2; j++)
                    res += (char)(sections[i][j] - '1' + 97);
                res += (char)(int.Parse(sections[i].Substring(sections[i].Length - 2, 2)) + 96);
            }
            string last = sections[sections.Length - 1];
            if(s[s.Length - 1] != '#')
                for (int i = 0; i < last.Length; i++)
                    res += (char)(last[i] - '1' + 97);
            return res;
        }
    }
}
