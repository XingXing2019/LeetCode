using System;

namespace FindThePunishmentNumberOfAnInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 10;
            Console.WriteLine(PunishmentNumber(n));
        }

        public static int PunishmentNumber(int n)
        {
            var res = 0;
            for (int i = 1; i <= n; i++)
            {
                var sqpt = i * i;
                if (!DFS(sqpt.ToString(), i, 0)) continue;
                res += sqpt;
            }
            return res;
        }

        public static bool DFS(string num, int target, int cur)
        {
            if (num.Length == 0 && cur == target)
                return true;
            for (int i = 1; i <= num.Length; i++)
            {
                var left = int.Parse(num.Substring(0, i));
                if (cur + left > target)
                    return false;
                if (DFS(num.Substring(i), target, cur + left))
                    return true;
            }
            return false;
        }
    }
}
