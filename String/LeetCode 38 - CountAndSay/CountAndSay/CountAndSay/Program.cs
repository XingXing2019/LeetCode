//本题的难点在理解题目，题目的意思是依次读取前一个数字所代表的字符串中，某一个数字的个数加上该数字的值。
//创建方法ReadString用于读取字符串。创建res记录结果，初始值设为空。创建count用于计数某个数字的个数，初始值设为1。
//从第二个元素遍历传入的字符串，如果当前数字与其前一数字相同，则让count加一。否则将count转换成字符串型，并与前一数字一起接入res。并使count复位为1。
//遍历结束后，将最后一次记录的count和字符串中最后一个数字接入res。最后返回res。
//在主方法中创建动态数组dp，其长度设为n + 1，用于记录每个每个数字所代表的的字符串。
//将dp[1]设为"1"，作为边界条件。i = 2 开始动态遍历dp，对当前元素的上一元素调用ReadString方法，所得结果即为当前元素对应的字符串。
//最后返回dp[n]即为结果。
using System;

namespace CountAndSay
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Console.WriteLine(CountAndSay(n));
        }
        static string CountAndSay(int n)
        {
            string[] dp = new string[n + 1];
            dp[1] = "1";
            for (int i = 2; i < dp.Length; i++)
            {
                dp[i] = ReadString(dp[i - 1]);
            }
            return dp[n];
        }
        static string ReadString(string str)
        {
            string res = "";
            int count = 1;
            for (int i = 1; i < str.Length; i++)
            {
                if(str[i] == str[i - 1])
                    count++;
                else
                {
                    res += count.ToString() + str[i - 1];
                    count = 1;
                }
            }
            res += count.ToString() + str[str.Length - 1];
            return res;
        }
        public string CountAndSay_O1Space(int n)
        {
            string pre = "1", cur = "";
            for (int i = 0; i < n - 1; i++)
            {
                int count = 0;
                for (int j = 0; j < pre.Length; j++)
                {
                    if (j != 0 && pre[j] != pre[j - 1])
                    {
                        cur += $"{count}{pre[j - 1]}";
                        count = 0;
                    }
                    count++;
                }
                if (count > 0) cur += $"{count}{pre[pre.Length - 1]}";
                pre = cur;
                cur = "";
            }
            return pre;
        }
    }
}
