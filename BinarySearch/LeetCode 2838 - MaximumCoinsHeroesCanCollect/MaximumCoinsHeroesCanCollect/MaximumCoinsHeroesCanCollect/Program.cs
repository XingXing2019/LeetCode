using System;

namespace MaximumCoinsHeroesCanCollect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long[] MaximumCoins(int[] heroes, int[] monsters, int[] coins)
        {
            var monsterCoins = new int[monsters.Length][];
            for (int i = 0; i < monsters.Length; i++)
                monsterCoins[i] = new[] { monsters[i], coins[i] };
            Array.Sort(monsterCoins, (a, b) => a[0] - b[0]);
            var prefix = new long[monsterCoins.Length];
            for (int i = 0; i < monsterCoins.Length; i++)
                prefix[i] = i == 0 ? monsterCoins[i][1] : prefix[i - 1] + monsterCoins[i][1];
            var res = new long[heroes.Length];
            for (int i = 0; i < heroes.Length; i++)
            {
                var index = BinarySearch(monsterCoins, heroes[i]);
                res[i] = index < 0 ? 0 : prefix[index];
            }
            return res;
        }

        private int BinarySearch(int[][] monsterCoins, int hero)
        {
            int li = 0, hi = monsterCoins.Length - 1;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (monsterCoins[mid][0] <= hero)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return hi;
        }
    }
}
