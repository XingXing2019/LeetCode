int[] MinCosts(int[] cost)
{
    var min = int.MaxValue;
    var res = new int[cost.Length];
    for (int i = 0; i < cost.Length; i++)
    {
        res[i] = Math.Min(min, cost[i]);
        min = Math.Min(min, cost[i]);
    }
    return res;
}