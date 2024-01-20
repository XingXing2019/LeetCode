int MinimumArrayLength(int[] nums)
{
    var freq = new Dictionary<int, int>();
    var min = int.MaxValue;
    foreach (var num in nums)
    {
        if (!freq.ContainsKey(num))
            freq[num] = 0;
        freq[num]++;
        min = Math.Min(min, num);
    }
    return (int)Math.Ceiling((double)freq[min] / 2);
}