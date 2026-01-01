long MinimumCost(int cost1, int cost2, int costBoth, int need1, int need2)
{
    long op1 = (long)cost1 * need1 + (long)cost2 * need2;
    long op2 = (long)costBoth * Math.Max(need1, need2);
    long op3 = (long)costBoth * Math.Min(need1, need2) + (long)cost1 * (need1 - Math.Min(need1, need2)) + (long)cost2 * (need2 - Math.Min(need1, need2));
    var ops = new List<long> { op1, op2, op3 };
    return ops.Min();
}