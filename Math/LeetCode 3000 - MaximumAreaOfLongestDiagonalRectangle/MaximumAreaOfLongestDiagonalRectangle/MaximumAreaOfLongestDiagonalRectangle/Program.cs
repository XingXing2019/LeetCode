int AreaOfMaxDiagonal(int[][] dimensions)
{
    dimensions = dimensions.OrderByDescending(x => Math.Sqrt((double)x[0] * x[0] + (double)x[1] * x[1])).ThenByDescending(x => x[0] * x[1]).ToArray();
    return dimensions[0][0] * dimensions[0][1];
}