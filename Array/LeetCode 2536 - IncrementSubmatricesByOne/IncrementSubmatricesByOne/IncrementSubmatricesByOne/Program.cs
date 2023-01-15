int n = 3;
int[][] queries = new int[][]
{
    new []{1, 1, 2, 2},
    new []{0, 0, 1, 1},
};

Console.WriteLine(RangeAddQueries(n, queries));

int[][] RangeAddQueries(int n, int[][] queries)
{
    var res = new int[n][];
    for (int i = 0; i < n; i++)
        res[i] = new int[n];
    foreach (var query in queries)
    {
        int rowStart = query[0], rowEnd = query[2];
        int colStart = query[1], colEnd = query[3];
        for (int i = rowStart; i <= rowEnd; i++)
        {
            res[i][colStart]++;
            if (colEnd + 1 < n)
                res[i][colEnd + 1]--;
        }
    }
    for (int i = 0; i < n; i++)
    {
        var count = 0;
        for (int j = 0; j < n; j++)
        {
            count += res[i][j];
            res[i][j] = count;
        }
    }
    return res;
}