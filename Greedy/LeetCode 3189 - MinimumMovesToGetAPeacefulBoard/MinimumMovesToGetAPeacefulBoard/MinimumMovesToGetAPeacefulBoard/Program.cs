int MinMoves(int[][] rooks)
{
    var rows = rooks.Select(x => x[0]).OrderBy(x => x).ToArray();
    var cols = rooks.Select(x => x[1]).OrderBy(x => x).ToArray();
    var res = 0;
    for (int i = 0; i < rooks.Length; i++)
        res += Math.Abs(rows[i] - i) + Math.Abs(cols[i] - i);
    return res;
}