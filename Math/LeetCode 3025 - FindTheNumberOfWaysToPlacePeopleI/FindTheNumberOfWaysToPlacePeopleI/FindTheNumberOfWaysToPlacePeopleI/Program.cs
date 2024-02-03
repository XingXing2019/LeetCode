int[][] points = new[]
{
    new[] { 0, 0 },
    new[] { 0, 3 },
};
Console.WriteLine(NumberOfPairs(points));

int NumberOfPairs(int[][] points)
{
    var res = 0;
    points = points.OrderBy(x => x[0]).ThenByDescending(x => x[1]).ToArray();
    for (int i = 0; i < points.Length; i++)
    {
        for (int j = i + 1; j < points.Length; j++)
        {
            if (points[i][0] > points[j][0] || points[i][1] < points[j][1] || AnyBetween(points, i, j))
                continue;
            res++;
        }
    }
    return res;
}

bool AnyBetween(int[][] points, int i, int j)
{
    for (int k = 0; k < points.Length; k++)
    {
        if (k == i || k == j)
            continue;
        if (points[k][0] >= points[i][0] && points[k][0] <= points[j][0] && points[k][1] <= points[i][1] && points[k][1] >= points[j][1])
            return true;
    }
    return false;
}