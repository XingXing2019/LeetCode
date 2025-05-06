var n = 2;
Console.WriteLine(SpecialGrid(n));

int[][] SpecialGrid(int n)
{
    var len = (int)Math.Pow(2, n);
    var res = new int[len][];
    for (int i = 0; i < len; i++)
        res[i] = new int[len];
    var val = 0;
    DFS(res, 0, len, 0, len, ref val);
    return res;
}

void DFS(int[][] res, int rLi, int rHi, int cLi, int cHi, ref int val)
{
    var size = rHi - rLi;
    if (size == 1)
    {
        res[rLi][cLi] = val++;
        return;
    }
    var rMid = rLi + size / 2;
    var cMid = cLi + size / 2;
    DFS(res, rLi, rMid, cMid, cHi, ref val);
    DFS(res, rMid, rHi, cMid, cHi, ref val);
    DFS(res, rMid, rHi, cLi, cMid, ref val);
    DFS(res, rLi, rMid, cLi, cMid, ref val);
}