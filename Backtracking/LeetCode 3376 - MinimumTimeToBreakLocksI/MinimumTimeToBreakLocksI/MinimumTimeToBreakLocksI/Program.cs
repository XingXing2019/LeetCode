var strength = new List<int> { 3, 4, 1 };
var k = 1;
Console.WriteLine(FindMinimumTime(strength, k));

int FindMinimumTime(IList<int> strength, int K)
{
    strength = strength.OrderBy(x => x).ToList();
    var res = int.MaxValue;
    DFS(strength, 0, new HashSet<int>(), K, 1, 0, ref res);
    return res;
}

void DFS(IList<int> strength, int count, HashSet<int> visited, int k, int x, int time, ref int res)
{
    if (count == strength.Count)
        res = Math.Min(res, time);
    for (int i = 0; i < strength.Count; i++)
    {
        if (visited.Contains(i)) continue;
        if (i != 0 && strength[i] == strength[i - 1] && !visited.Contains(i - 1)) continue;
        visited.Add(i);
        var cost = strength[i] % x == 0 ? strength[i] / x : strength[i] / x + 1;
        DFS(strength, count + 1, visited, k, x + k, time + cost, ref res);
        visited.Remove(i);
    }
}