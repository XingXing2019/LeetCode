int MostFrequentEven(int[] nums)
{
    var dict = new Dictionary<int, int>();
    var max = 0;
    foreach (var num in nums)
    {
        if (num % 2 != 0) continue;
        if (!dict.ContainsKey(num))
            dict[num] = 0;
        dict[num]++;
        max = Math.Max(max, dict[num]);
    }
    return dict.Count == 0 ? -1 : dict.Where(x => x.Value == max).Min(x => x.Key);
}
