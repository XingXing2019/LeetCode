var n = 4;
int[][] pick = new[]
{
    new[] { 0, 0 },
    new[] { 1, 0 },
    new[] { 1, 0 },
    new[] { 2, 1 },
    new[] { 2, 1 },
    new[] { 2, 0 },
};
Console.WriteLine(WinningPlayerCount(n, pick));

int WinningPlayerCount(int n, int[][] pick)
{
    var record = new Dictionary<int, int>[n];
    for (int i = 0; i < n; i++)
        record[i] = new Dictionary<int, int>();
    foreach (var p in pick)
    {
        if (!record[p[0]].ContainsKey(p[1]))
            record[p[0]][p[1]] = 0;
        record[p[0]][p[1]]++;
    }
    var res = 0;
    for (int i = 0; i < record.Length; i++)
    {
        if (record[i].Count == 0 || i >= record[i].Max(x => x.Value)) continue;
        res++;
    }
    return res;
}