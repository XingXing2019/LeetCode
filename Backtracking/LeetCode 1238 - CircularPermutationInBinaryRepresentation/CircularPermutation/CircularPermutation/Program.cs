int n = 2, start = 3;
Console.WriteLine(CircularPermutation(n, start));

IList<int> CircularPermutation(int n, int start)
{
    var res = new List<int>();
    DFS(n, start, new HashSet<int>(), ref res);
    return res;
}

void DFS(int n, int cur, HashSet<int> visited, ref List<int> res)
{
    if (!visited.Add(cur) || res.Count == 1 << n)
        return;
    if (visited.Count == 1 << n)
        res = new List<int>(visited);
    for (int i = 0; i <= n; i++)
    {
        var next = ((cur >> i) & 1) == 1 ? cur - (1 << i) : cur + (1 << i);
        DFS(n, next, visited, ref res);
    }
    visited.Remove(cur);
}