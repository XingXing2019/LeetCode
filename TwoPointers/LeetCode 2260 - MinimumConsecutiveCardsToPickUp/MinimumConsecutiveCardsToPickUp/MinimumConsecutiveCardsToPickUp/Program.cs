int[] nums = { 5, 86, 30, 27, 30, 85, 47 };
Console.WriteLine(MinimumCardPickup(nums));

int MinimumCardPickup(int[] cards)
{
    var dict = new Dictionary<int, int>();
    int li = 0, hi = 0, res = int.MaxValue;
    while (hi < cards.Length)
    {
        if (!dict.ContainsKey(cards[hi]))
            dict[cards[hi]] = 0;
        dict[cards[hi]]++;
        while (li < hi && dict[cards[hi]] > 1)
        {
            res = Math.Min(res, hi - li + 1);
            dict[cards[li++]]--;
        }
        hi++;
    }
    if (dict[cards[--hi]] > 1)
        res = Math.Min(res, hi - li + 1);
    return res == int.MaxValue ? -1 : res;
}