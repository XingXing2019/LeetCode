int[][] bottomLeft = new[]
{
    new[] { 4, 6 },
    new[] { 7, 2 },
};

int[][] topRight = new[]
{
    new[] { 9, 8 },
    new[] { 8, 5 },
};

Console.WriteLine(LargestSquareArea(bottomLeft, topRight));

long LargestSquareArea(int[][] bottomLeft, int[][] topRight)
{
    var squares = new int[bottomLeft.Length][];
    for (int i = 0; i < bottomLeft.Length; i++)
        squares[i] = new[] { bottomLeft[i][0], bottomLeft[i][1], topRight[i][0], topRight[i][1] };
    var res = 0L;
    for (int i = 0; i < squares.Length; i++)
    {
        for (int j = i + 1; j < squares.Length; j++)
        {
            int[] s1 = squares[i], s2 = squares[j];
            if (s1[2] <= s2[0] || s1[0] >= s2[2] || s1[3] <= s2[1] || s1[1] >= s2[3]) continue;
            var minW = Math.Min(s1[2], s2[2]) - Math.Max(s1[0], s2[0]);
            var minH = Math.Min(s1[3], s2[3]) - Math.Max(s1[1], s2[1]);
            long len = Math.Min(minW, minH);
            res = Math.Max(res, len * len);
        }
    }
    return res;
}