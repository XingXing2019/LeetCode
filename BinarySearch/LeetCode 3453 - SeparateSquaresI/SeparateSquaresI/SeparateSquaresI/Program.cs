int[][] squares =
{
    new[] { 522261215, 954313664, 461744743 },
    new[] { 628661372, 718610752, 21844764 },
};
Console.WriteLine(SeparateSquares(squares));

double SeparateSquares(int[][] squares)
{
    double li = squares.Min(x => (double)x[1]), hi = squares.Max(x => (double)x[1] + x[2]), line = 0, res = 0;
    while (hi - li > 0.00001)
    {
        var mid = (hi + li) / 2;
        var areas = GetAreas(squares, mid);
        if (Math.Abs(areas[0] - areas[1]) < 0.00001)
        {
            line = mid;
            break;
        }
        if (areas[0] < areas[1])
            hi = mid;
        else
            li = mid;
    }
    if (line == 0) line = li;
    foreach (var square in squares)
    {
        int bottom = square[1], top = square[1] + square[2];
        if (bottom < line && line < top)
            return line;
        if (line >= top)
            res = Math.Max(res, top);
    }
    return res;
}

double[] GetAreas(int[][] squares, double line)
{
    double up = 0, down = 0;
    foreach (var square in squares)
    {
        int bottom = square[1], top = square[1] + square[2];
        double area = (double)square[2] * square[2];
        if (top <= line)
            down += area;
        else if (line <= bottom)
            up += area;
        else
        {
            var ratio = (line - bottom) / square[2];
            down += area * ratio;
            up += area * (1 - ratio);
        }
    }
    return new[] { up, down };
}