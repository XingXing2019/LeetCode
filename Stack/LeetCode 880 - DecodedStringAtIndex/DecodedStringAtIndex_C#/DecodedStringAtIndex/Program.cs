//暴力生成字符串会超内存。应该遍历S，按照要求计算生成字符串的长度lenCount。当字符串长度大于K时，终止遍历。并记录此时i的位置。
//然后从i向回推如果遇到数字，则令lenCount除等于当前数字，代表反向将字符串长度减小。并让K模等于当前lenCount。
//如果是字母则检查如果K可以被lenCount整除，则当前字母为结果。否则让lenCount减一。
using System;
using System.Text;

namespace DecodedStringAtIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "yyuele72uthzyoeut7oyku2yqmghy5luy9qguc28ukav7an6a2bvizhph35t86qicv4gyeo6av7gerovv5lnw47954bsv2xruaej";
            int K = 123365626;
            Console.WriteLine(DecodeAtIndex(S, K));
        }
        static string DecodeAtIndex(string S, int K)
        {
            long lenCount = 0;
            int i = 0;
            for (; lenCount < K; i++)
                lenCount = char.IsDigit(S[i]) ? lenCount * (S[i] - '0') : lenCount + 1;
            i--;
            while (true)
            {
                if (char.IsDigit(S[i]))
                {
                    lenCount /= S[i] - '0';
                    K %= (int)lenCount;
                }
                else if (K % lenCount == 0)
                    return S[i].ToString();
                else
                    lenCount--;
                i--;
            }
        }
    }
}
