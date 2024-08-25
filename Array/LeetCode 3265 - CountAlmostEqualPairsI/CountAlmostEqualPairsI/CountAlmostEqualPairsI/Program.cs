int[] nums = { 3, 12, 30, 17, 21 };
Console.WriteLine(CountPairs(nums));

int CountPairs(int[] nums)
{
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (IsAlmostSame(nums[i], nums[j]))
                res++;
        }
    }
    return res;
}

bool IsAlmostSame(int x, int y)
{
    var count = 0;
    var dict = new Dictionary<int, int>();
    while (x != 0 || y != 0)
    {
        if (!dict.ContainsKey(x % 10))
            dict[x % 10] = 0;
        dict[x % 10]++;
        if (dict[x % 10] == 0)
            dict.Remove(x % 10);
        if (!dict.ContainsKey(y % 10))
            dict[y % 10] = 0;
        dict[y % 10]--;
        if (dict[y % 10] == 0)
            dict.Remove(y % 10);
        if (x % 10 != y % 10)
            count++;
        x /= 10;
        y /= 10;
    }
    return dict.Count == 0 && (count == 2 || count == 0);
}