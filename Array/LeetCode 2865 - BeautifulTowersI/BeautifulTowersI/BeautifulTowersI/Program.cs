var maxHeights = new List<int> { 5, 3, 4, 1, 1 };
Console.WriteLine(MaximumSumOfHeights(maxHeights));

long MaximumSumOfHeights(IList<int> maxHeights)
{
    long res = 0;
    for (int i = 0; i < maxHeights.Count; i++)
        res = Math.Max(res, GetSum(maxHeights, i));
    return res;
}

long GetSum(IList<int> maxHeights, int index)
{
    long res = 0;
    var last = maxHeights[index];
    for (int i = index - 1; i >= 0; i--)
    {
        var cur = Math.Min(last, maxHeights[i]);
        res += cur;
        last = cur;
    }
    last = maxHeights[index];
    for (int i = index + 1; i < maxHeights.Count; i++)
    {
        var cur = Math.Min(last, maxHeights[i]);
        res += cur;
        last = cur;
    }
    return res + maxHeights[index];
}