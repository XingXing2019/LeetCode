int[][] coords = new[]
{
    new[] { 1, 1 },
    new[] { 1, 2 },
    new[] { 3, 2 },
    new[] { 3, 3 },
};
Console.WriteLine(MaxArea(coords));

long MaxArea(int[][] coords)
{
    int maxX = 0, minX = int.MaxValue, maxY = 0, minY = int.MaxValue;
    var dictX = new Dictionary<int, List<int>>();
    var dictY = new Dictionary<int, List<int>>();
    var res = -1L;
    foreach (var c in coords)
    {
        int x = c[0], y = c[1];
        maxX = Math.Max(maxX, x);
        minX = Math.Min(minX, x);
        maxY = Math.Max(maxY, y);
        minY = Math.Min(minY, y);
        if (!dictX.ContainsKey(x))
            dictX[x] = new List<int>();
        dictX[x].Add(y);
        if (!dictY.ContainsKey(y))
            dictY[y] = new List<int>();
        dictY[y].Add(x);
    }
    foreach (var x in dictX.Keys)
    {
        if (dictX[x].Count < 2) continue;
        int min = int.MaxValue, max = 0;
        foreach (var y in dictX[x])
        {
            min = Math.Min(min, y);
            max = Math.Max(max, y);
        }
        if (maxX != x)
            res = Math.Max(res, (long)(max - min) * (maxX - x));
        if (minX != x)
            res = Math.Max(res, (long)(max - min) * (x - minX));
    }

    foreach (var y in dictY.Keys)
    {
        if (dictY[y].Count < 2) continue;
        int min = int.MaxValue, max = 0;
        foreach (var x in dictY[y])
        {
            min = Math.Min(min, x);
            max = Math.Max(max, x);
        }
        if (maxY != y)
            res = Math.Max(res, (long)(max - min) * (maxY - y));
        if (minY != y)
            res = Math.Max(res, (long)(max - min) * (y - minY));
    }
    return res;
}