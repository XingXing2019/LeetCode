//创建v1Pos和v2Pos指针用于遍历字符串。在v1Pos和v2Pos都没有越界的条件下遍历字符串。
//创建v1Num和v2Num记录小数点之间的数值，初始值设为0。在v1Pos没有越界并且v1Pos所指向字符不为'.'的情况下遍历version1，将遍历到的数字记录如v1Num。遍历结束后使v1Pos加一。
//同样做法获取v2Num。比较v1Num和v2Num，如果两个数字不相同，则返回相应结果。如果相同则不用操作。
//遍历结束后判断v1Pos和v2Pos那个还没有到达字符串的尽头，继续遍历没有到达尽头的字符串。如果发现有比0大的数字则返回相应结果。
//如果上述操作全部返程后仍没有返回结果，则证明version1和version2相同。
using System;

namespace CompareVersionNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string version1 = "1.0.1";
            string version2 = "1";
            Console.WriteLine(CompareVersion(version1, version2));
        }
        static int CompareVersion(string version1, string version2)
        {
            int v1Pos = 0;
            int v2Pos = 0;
            while (v1Pos < version1.Length && v2Pos < version2.Length)
            {
                double v1Num = 0;
                double v2Num = 0;
                while (v1Pos < version1.Length && version1[v1Pos] != '.')
                {
                    int tem = version1[v1Pos] - '0';
                    v1Num = v1Num * 10 + tem;
                    v1Pos++;
                }
                v1Pos++;
                while (v2Pos < version2.Length && version2[v2Pos] != '.')
                {
                    int tem = version2[v2Pos] - '0';
                    v2Num = v2Num * 10 + tem;
                    v2Pos++;
                }
                v2Pos++;
                if (v1Num > v2Num)
                    return 1;
                else if (v1Num < v2Num)
                    return -1;
            }
            if (v1Pos < version1.Length)
            {
                for (int i = v1Pos; i < version1.Length; i++)
                    if (version1[i] - '0' > 0 && version1[i] != '.')
                        return 1;
            }
            else if (v2Pos < version2.Length)
            {
                for (int i = v2Pos; i < version2.Length; i++)
                    if (version2[i] - '0' > 0 && version2[i] != '.')
                        return -1;
            }
            return 0;
        }
        static int CompareVersion_Simplified(string version1, string version2)
        {
            var v1 = version1.Split('.');
            var v2 = version2.Split('.');
            int p1 = 0, p2 = 0;
            while (p1 < v1.Length && p2 < v2.Length)
            {
                int num1 = int.Parse(v1[p1++]);
                int num2 = int.Parse(v2[p2++]);
                if (num1 < num2)
                    return -1;
                if (num1 > num2)
                    return 1;
            }
            while (p1 < v1.Length)
            {
                int num = int.Parse(v1[p1++]);
                if (num != 0)
                    return 1;
            }
            while (p2 < v2.Length)
            {
                int num = int.Parse(v2[p2++]);
                if (num != 0)
                    return -1;
            }
            return 0;
        }
    }
}
