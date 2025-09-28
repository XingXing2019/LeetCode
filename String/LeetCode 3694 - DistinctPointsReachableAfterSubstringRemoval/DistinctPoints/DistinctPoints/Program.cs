var s = "LUL";
var k = 1;
Console.WriteLine(DistinctPoints(s, k));

int DistinctPoints(string s, int k)
{
    var removed = new int[2];
    var dirs = new int[s.Length][];
    for (int i = 0; i < dirs.Length; i++)
        dirs[i] = new int[2];
    for (int i = 0; i < s.Length; i++)
    {
        if (i != 0)
            Array.Copy(dirs[i - 1], dirs[i], 2);
        if (s[i] == 'U' || s[i] == 'D')
        {
            if (i < k) removed[0] += s[i] == 'U' ? -1 : 1;
            dirs[i][0] += s[i] == 'U' ? -1 : 1;
        }
        else
        {
            if (i < k) removed[1] += s[i] == 'L' ? -1 : 1;
            dirs[i][1] += s[i] == 'L' ? -1 : 1;
        }
    }
    int x = dirs[^1][0] - removed[0], y = dirs[^1][1] - removed[1];
    var res = new HashSet<string> { $"{x}:{y}" };
    for (int i = k; i < s.Length; i++)
    {
        if (s[i] == 'U' || s[i] == 'D')
            removed[0] += s[i] == 'U' ? -1 : 1;
        else
            removed[1] += s[i] == 'L' ? -1 : 1;
        if (s[i - k] == 'U' || s[i - k] == 'D')
            removed[0] -= s[i - k] == 'U' ? -1 : 1;
        else
            removed[1] -= s[i - k] == 'L' ? -1 : 1;
        x = dirs[^1][0] - removed[0];
        y = dirs[^1][1] - removed[1];
        res.Add($"{x}:{y}");
    }
    return res.Count;
}