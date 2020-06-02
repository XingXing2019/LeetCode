//应用动态规划思想，如果某一位上的数字能与其前一位的数字组成的两位数大于或等于26，则以此数字结尾的字符串解码个数等于以其前两位数字结尾解码个数的总和。
//如果某一位上的数字能与其前一位的数字组成的两位数小于26，则以此数字结尾的字符串解码个数等于以其前一位数字结尾的解码个数。但是要注意判断等于0的特殊情况。
//创建动态数组dp，长度与s长度相同。如果s第一位是0，则直接返回0，否则将dp[0]设为1。如果s长度小于2，则返回s的长度。
//当s第二位时0时，如果s第一位是1或者2，则将dp[1]设为1，否则返回0。当s第二位不是0时，如果s前两位组成数字大于26，则将dp[1]设为1，否则设为2。
//从dp第三个元素开始遍历。当s[i]为0时，如果s[i - 1]为1或者2，则将dp[i]设为dp[i - 2]。因为此时s[i]必须和s[i - 1]组成一个数字，所以dp[i]与dp[i - 2]相关。
//当s[i]为0时，如果s[i - 1]不为1或者2时，则返回0，因为无论如果s[i]都不能被解码。
//当s[i]不为0时，如果s[i - 1]为0，则将dp[i]设为dp[i - 1]。因为此时s[i]只能独立组成数字。
//如果s[i - 1]不为0，当s[i]与s[i - 1]组成的数字小于等于26时，将dp[i]设为dp[i - 1]与dp[i- 2]之和。否则将dp[i]设为dp[i - 1].
using System;

namespace DecodeWays
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "12101";
            Console.WriteLine(NumDecodings(s));
        }
        static int NumDecodings(string s)
        {
            int[] dp = new int[s.Length];
            if (s[0] == '0')
                return 0;
            else
                dp[0] = 1;
            if (s.Length < 2)
                return s.Length;
            if (s[1] == '0')
            {
                if (s[0] == '1' || s[0] == '2')
                    dp[1] = 1;
                else
                    return 0;
            }
            else
                dp[1] = int.Parse(s.Substring(0, 2)) <= 26 ? 2 : 1;
            for (int i = 2; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    if (s[i - 1] == '1' || s[i - 1] == '2')
                        dp[i] = dp[i - 2];
                    else
                        return 0;
                }
                else
                {
                    if (s[i - 1] == '0')
                        dp[i] = dp[i - 1];
                    else
                    {
                        if (int.Parse(s.Substring(i - 1, 2)) <= 26)
                            dp[i] = dp[i - 1] + dp[i - 2];
                        else
                            dp[i] = dp[i - 1];
                    }
                }
            }
            return dp[dp.Length - 1];
        }
    }
}
