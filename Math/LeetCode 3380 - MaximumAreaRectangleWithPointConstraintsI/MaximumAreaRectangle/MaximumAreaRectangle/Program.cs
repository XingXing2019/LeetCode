int[][] points = new[]
{
    new[] { 10, 8 },
    new[] { 6, 7 },
    new[] { 10, 7 },
    new[] { 6, 8 },
    new[] { 8, 4 },
};
Console.WriteLine(MaxRectangleArea(points));

int MaxRectangleArea(int[][] points)
{
    points = points.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();
    var set = new HashSet<string>(points.Select(x => $"{x[0]}:{x[1]}"));
    var res = -1;
    for (int i = 0; i < points.Length; i++)
    {
        for (int j = i + 1; j < points.Length; j++)
        {
            int[] p1 = points[i], p2 = points[j];
            int xLi = Math.Min(p1[0], p2[0]), xHi = Math.Max(p1[0], p2[0]);
            int yLi = Math.Min(p1[1], p2[1]), yHi = Math.Max(p1[1], p2[1]);
            int[] p3 = { xLi, yLi }, p4 = { xHi, yHi };
            if (p1[0] == p2[0] || p1[1] == p2[1] || p1[1] < p2[1])
                continue;
            if (!set.Contains($"{p3[0]}:{p3[1]}") || !set.Contains($"{p4[0]}:{p4[1]}") || !IsValid(points, p1, p2, p3, p4))
                continue;
            res = Math.Max(res, Math.Abs(p1[0] - p2[0]) * Math.Abs(p1[1] - p2[1]));
        }
    }
    return res;
}

bool IsValid(int[][] points, int[] p1, int[] p2, int[] p3, int[] p4)
{
    int xLi = Math.Min(p1[0], p2[0]), xHi = Math.Max(p1[0], p2[0]);
    int yLi = Math.Min(p1[1], p2[1]), yHi = Math.Max(p1[1], p2[1]);
    foreach (var point in points)
    {
        var p = $"{point[0]}:{point[1]}";
        if (p == $"{p1[0]}:{p1[1]}" || p == $"{p2[0]}:{p2[1]}" || p == $"{p3[0]}:{p3[1]}" || p == $"{p4[0]}:{p4[1]}")
            continue;
        if (point[0] >= xLi && point[0] <= xHi && point[1] >= yLi && point[1] <= yHi)
            return false;
    }
    return true;
}