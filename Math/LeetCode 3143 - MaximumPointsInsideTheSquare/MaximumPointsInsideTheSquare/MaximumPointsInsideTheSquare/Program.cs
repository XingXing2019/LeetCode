int[][] points = new[]
{
    new[] { 2, 2 },
    new[] { -1, -2 },
    new[] { -4, 4 },
    new[] { -3, 1 },
    new[] { 3, -3 },
};
var s = "abdca";
Console.WriteLine(MaxPointsInsideSquare(points, s));

int MaxPointsInsideSquare(int[][] points, string s)
{
    var res = 0;
    var dict = new Dictionary<char, List<int>>();
    for (int i = 0; i < points.Length; i++)
    {
        if (!dict.ContainsKey(s[i]))
            dict[s[i]] = new List<int>();
        dict[s[i]].Add(Math.Max(Math.Abs(points[i][0]), Math.Abs(points[i][1])));
    }
    foreach (var l in dict.Keys)
        dict[l].Sort();
    foreach (var l in dict.Keys)
    {
        var target = dict[l][0];
        if (dict[l].Count > 1 && dict[l][1] == target)
            continue;
        var count = 1;
        foreach (var c in dict.Keys)
        {
            if (l == c) continue;
            var index = BinarySearch(dict[c], target);
            if (index > 1)
            {
                count = -1;
                break;
            }
            count += index;
        }
        res = Math.Max(res, count);
    }
    return res;
}

int BinarySearch(List<int> lens, int target)
{
    int li = 0, hi = lens.Count - 1;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (lens[mid] <= target)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return li;
}