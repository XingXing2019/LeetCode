//创建res记录结果。创建point指针用来遍历字符串，初始值设为0。创建times用来记录次数，初始值设为k。
//遍历字符串，创建tem用来记录本次遍历所得结果。先依次将point指向的字符倒着存入tem，同时用times辅助计数。每记录依次point向前移动一位。
//再将point指向的字符正着存入tem，同时使用times辅助计数。每记录依次point向前移动一位。最后将tem存入res。
//注意所有遍历时point不要越界。
using System;

namespace ReverseStringII
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abcdefg";
            int k = 3;
            Console.WriteLine(ReverseStr(s, k));
        }
        static string ReverseStr(string s, int k)
        {
            string res = "";
            int point = 0;
            int times = k;
            while (point < s.Length)
            {
                string tem = "";
                while (times > 0 && point < s.Length)
                {
                    tem = s[point] + tem;
                    times--;
                    point++;
                }
                while (times < k && point < s.Length)
                {
                    tem += s[point];
                    times++;
                    point++;
                }
                res += tem;
            }
            return res;
        }
    }
}
