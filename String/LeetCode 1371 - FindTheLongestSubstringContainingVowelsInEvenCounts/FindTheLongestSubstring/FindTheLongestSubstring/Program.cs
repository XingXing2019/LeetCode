//用使用二维数组记录每个位置左边元音字母分别的个数。要将一个全部为0的数组加入record头部，代表在第一个字母之前没有任何元音字母。
//两个指针一个正向，一个逆向遍历record，寻找最长的符合条件的子串。
using System;

namespace FindTheLongestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "eleetminicoworoep";
            Console.WriteLine(FindTheLongestSubstring(s));
        }
        static int FindTheLongestSubstring(string s)
        {
            var record = new int[s.Length + 1][];
            record[0] = new int[26];
            for (int i = 1; i < s.Length + 1; i++)
            {
                record[i] = new int[26];
                Array.Copy(record[i-1], record[i], 26);
                if (s[i - 1] == 'a' || s[i - 1] == 'e' || s[i - 1] == 'i' || s[i - 1] == 'o' || s[i - 1] == 'u')
                    record[i][s[i - 1] - 'a']++;
            }
            var res = 0;
            for (int i = 0; i < record.Length; i++)
            {
                for (int j = record.Length-1; j > i; j--)
                {
                    if (j - i < res)
                        break;
                    if (CompareArrays(record[i], record[j]))
                    {
                        res = Math.Max(res, j - i);
                        break;
                    }
                }
            }
            return res;
        }
        static bool CompareArrays(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
                if ((arr2[i] - arr1[i]) % 2 != 0)
                    return false;
            return true;
        }
    }
}
