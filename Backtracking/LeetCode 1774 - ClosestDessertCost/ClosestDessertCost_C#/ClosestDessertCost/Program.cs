using System;

namespace ClosestDessertCost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int ClosestCost(int[] baseCosts, int[] toppingCosts, int target)
        {
            int res = int.MaxValue;
            foreach (var baseCost in baseCosts)
                DFS(toppingCosts, baseCost, target, 0, ref res);
            return res;
        }

        public void DFS(int[] toppingCosts, int cost, int target, int index, ref int res)
        {
            if (Math.Abs(target - res) > Math.Abs(target - cost))
                res = cost;
            if (index == toppingCosts.Length || cost > target)
                return;
            for (int i = 0; i <= 2; i++)
                DFS(toppingCosts, cost + toppingCosts[index] * i, target, index + 1, ref res);
        }
    }
}
