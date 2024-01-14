int MaxFrequencyElements(int[] nums)
{
    var freq = new Dictionary<int, int>();
    var max = 0;
    foreach (var num in nums)
    {
        if (!freq.ContainsKey(num))
            freq[num] = 0;
        freq[num]++;
        max = Math.Max(max, freq[num]);
    }
    return freq.Count(x => x.Value == max) * max;
}