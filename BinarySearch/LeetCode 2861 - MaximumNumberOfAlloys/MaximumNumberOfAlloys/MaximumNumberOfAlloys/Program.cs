int n = 1, k = 1, budget = 100000000;
int[][] composition = new int[][]
{
    new int[] { 1 },
};
var stock = new List<int> { 83358995 };
var cost = new List<int> { 1 };
Console.WriteLine(MaxNumberOfAlloys(n, k, budget, composition, stock, cost));

int MaxNumberOfAlloys(int n, int k, int budget, IList<IList<int>> composition, IList<int> stock, IList<int> cost)
{
    var res = 0;
    foreach (var machine in composition)
    {
        int li = 0, hi = int.MaxValue;
        while (li <= hi)
        {
            var mid = li + (hi - li) / 2;
            if (IsEnough(machine, stock, cost, budget, mid))
                li = mid + 1;
            else
                hi = mid - 1;
        }
        res = Math.Max(res, hi);
    }
    return res;
}

bool IsEnough(IList<int> machine, IList<int> stock, IList<int> cost, int budget, long alloys)
{
    long total = 0;
    for (int i = 0; i < machine.Count; i++)
        total += Math.Max(0, machine[i] * alloys - stock[i]) * cost[i];
    return budget >= total;
}