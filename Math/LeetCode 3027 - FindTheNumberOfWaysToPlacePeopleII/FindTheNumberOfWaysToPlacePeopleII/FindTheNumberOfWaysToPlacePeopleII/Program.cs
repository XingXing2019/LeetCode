int NumberOfPairs(int[][] points)
{
    var res = 0;
    points = points.OrderBy(x => x[0]).ThenByDescending(x => x[1]).ToArray();
    for (int i = 0; i < points.Length; i++)
    {
        var max = int.MinValue;
        for (int j = i + 1; j < points.Length; j++)
        {
            if (points[j][1] > points[i][1]) continue;
            if (points[j][1] > max) res++;
            max = Math.Max(max, points[j][1]);
        }
    }
    return res;
}