int MinRectanglesToCoverPoints(int[][] points, int w)
{
    points = points.OrderBy(x => x[0]).ToArray();
    int res = 1, left = points[0][0];
    for (int i = 1; i < points.Length; i++)
    {
        if (points[i][0] - left > w)
        {
            left = points[i][0];
            res++;
        }
    }
    return res;
}