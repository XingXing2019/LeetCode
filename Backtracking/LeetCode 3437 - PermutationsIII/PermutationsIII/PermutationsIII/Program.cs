int[][] Permute(int n)
{
    var res = new List<int[]>();
    DFS(n, 0, new HashSet<int>(), res);
    return res.ToArray();
}

void DFS(int n, int last, HashSet<int> nums, List<int[]> res)
{
    if (nums.Count == n)
    {
        res.Add(new List<int>(nums).ToArray());
        return;
    }
    for (int i = 1; i <= n; i++)
    {
        if (nums.Contains(i) || last != 0 && i % 2 == last % 2)
            continue;
        nums.Add(i);
        DFS(n, i, nums, res);
        nums.Remove(i);
    }
}