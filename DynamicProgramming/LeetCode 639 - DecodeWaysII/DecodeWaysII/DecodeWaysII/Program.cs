using System;

namespace DecodeWaysII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int NumDecodings(string s)
        {
            int mod = 1_000_000_000 + 7;
            if (s[0] == '0') return 0;
            var dp = new int[s.Length];
            dp[0] = s[0] == '*' ? 9 : 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == '*')
                {
                    dp[i] = dp[i - 1] * 9;
                    if (s[i - 1] == '1') dp[i] += i == 1 ? 9 : dp[i - 2] * 9;
                    else if (s[i - 1] == '2') dp[i] += i == 1 ? 6 : dp[i - 2] * 6;
                    else if (s[i - 1] == '*') dp[i] += i == 1 ? 15 : dp[i - 2] * 15;
                }
                else
                {
                    if (s[i - 1] == '*')
                    {
                        if (s[i] == '0')
                            dp[i] = i == 1 ? 2 : dp[i - 2] * 2;
                        else
                        {
                            dp[i] = dp[i - 1];
                            if (s[i] - '0' <= 6) dp[i] += i == 1 ? 2 : dp[i - 2] * 2;
                            else dp[i] += dp[i - 2];
                        }
                    }
                    else
                    {
                        var num = int.Parse(s.Substring(i - 1, 2));
                        if (s[i] == '0')
                        {
                            if (num == 0 || num > 20) return 0;
                            dp[i] = i == 1 ? 1 : dp[i - 2];
                        }
                        else if (num > 26 || num < 10) dp[i] = dp[i - 1];
                        else dp[i] = i == 1 ? dp[i - 1] + 1 : dp[i - 1] + dp[i - 2];
                    }
                }
                dp[i] %= mod;
            }
            return dp[^1];
        }
    }
}
