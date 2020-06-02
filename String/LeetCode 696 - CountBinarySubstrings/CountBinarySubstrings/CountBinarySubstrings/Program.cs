//创建count记录结果，创建cur代表当前数字之前和其相同数字的个数，初始值设为1(因为要从第二个数字开始遍历)，创建prev代表当前数字之前和其不同数字的个数，初始值设为0.
//从第二个数字开始遍历，如果当前数字和其前一数字相同，则使cur加一。否则，将prev设为cur，将cur设为1.
//每次循环时判断prev是否大于等于cur，如果大于等于，则以当前数字结尾，之前一定有一个满足条件的子串，则count加一。
using System;

namespace CountBinarySubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "00110011";
            Console.WriteLine(CountBinarySubstrings(s));
        }
        static int CountBinarySubstrings(string s)
        {
            int count = 0;
            int cur = 1;
            int prev = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if(s[i] == s[i - 1])
                    cur++;
                else
                {
                    prev = cur;
                    cur = 1;
                }
                if (prev >= cur)
                    count++;
            }
            return count;
        }
    }
}
