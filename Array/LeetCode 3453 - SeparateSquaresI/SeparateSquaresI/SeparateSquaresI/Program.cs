double SeparateSquares(int[][] squares)
{
    var areas = new int[squares.Length][];
    for (int i = 0; i < squares.Length; i++)
    {
        int x = squares[i][0], y = squares[i][1], l = squares[i][2];
        areas[i] = new[] { y + l, l * l };
    }
    Array.Sort(areas, (a, b) => a[0] - b[0]);

}