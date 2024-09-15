int[] GetSneakyNumbers(int[] nums)
{
    var dict = new Dictionary<int, int>();
    foreach (var num in nums)
    {
        if (!dict.ContainsKey(num))
            dict[num] = 0;
        dict[num]++;
    }
    return dict.Where(x => x.Value == 2).Select(x => x.Key).ToArray();
}