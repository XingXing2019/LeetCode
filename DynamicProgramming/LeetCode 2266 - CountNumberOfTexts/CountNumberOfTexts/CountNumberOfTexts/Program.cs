using System;

namespace CountNumberOfTexts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pressKeys = "22223";
            Console.WriteLine(CountTexts(pressKeys));
        }

        public static int CountTexts(string pressedKeys)
        {
            long mod = 1_000_000_000 + 7;
            var keys = new int[10];
            for (int i = 0; i < keys.Length; i++)
                keys[i] = i == 7 || i == 9 ? 4 : 3;
            var dp = new long[pressedKeys.Length + 1];
            dp[0] = 1;
            for (int i = 1; i < dp.Length; i++)
            {
                var keyCount = keys[pressedKeys[i - 1] - '0'];
                long count = 0;
                var index = i - 1;
                do
                {
                    count = (count + dp[index--]) % mod;
                    keyCount--;
                } while (index >= 0 && keyCount != 0 && pressedKeys[i - 1] == pressedKeys[index]);
                dp[i] = count;
            }
            return (int) (dp[^1] % mod);
        }
    }
}
