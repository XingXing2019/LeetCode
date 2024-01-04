var n = 3;
Console.WriteLine(SelfDivisiblePermutationCount(n));

int SelfDivisiblePermutationCount(int n)
{
    var res = 0;
    BackTracking(new HashSet<int>(), n, ref res);
    return res;
}

void BackTracking(HashSet<int> visited, int n, ref int res)
{
    if (visited.Count == n)
        res++;
    for (int i = 1; i <= n; i++)
    {
        if (visited.Contains(i) || (i % (visited.Count + 1) != 0 && (visited.Count + 1) % i != 0)) continue;
        visited.Add(i);
        BackTracking(visited, n, ref res);
        visited.Remove(i);
    }
}