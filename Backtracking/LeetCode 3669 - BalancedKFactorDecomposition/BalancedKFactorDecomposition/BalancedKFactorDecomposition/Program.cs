int n = 44, k = 3;
Console.WriteLine(MinDifference(n, k));

int[] MinDifference(int n, int k)
{
    var divisors = new List<int>();
    for (int i = 1; i <= Math.Sqrt(n); i++)
    {
        if (n % i != 0) continue;
        divisors.Add(i);
        divisors.Add(n / i);
    }
    divisors.Sort();
    var lists = new List<List<int>>();
    DFS(divisors, 0, 1, n, k, new List<int>(), lists);
    var res = new int[k];
    var min = int.MaxValue;
    foreach (var list in lists)
    {
        list.Sort();
        if (list[^1] - list[0] >= min) continue;
        res = list.ToArray();
        min = list[^1] - list[0];
    }
    return res;
}

void DFS(List<int> divisors, int start, int product, int n, int k, List<int> nums, List<List<int>> res)
{
    if (product > n || k < 0)
        return;
    if (n == product && k == 0)
    {
        res.Add(new List<int>(nums));
        return;
    }
    for (var i = start; i < divisors.Count; i++)
    {
        var num = divisors[i];
        nums.Add(num);
        DFS(divisors, i, product * num, n, k - 1, nums, res);
        nums.RemoveAt(nums.Count - 1);
    }
}