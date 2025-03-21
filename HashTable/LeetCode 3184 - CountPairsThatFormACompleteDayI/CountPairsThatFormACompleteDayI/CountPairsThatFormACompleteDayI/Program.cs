﻿int CountCompleteDayPairs(int[] hours)
{
    var freq = new Dictionary<int, int>();
    var res = 0;
    foreach (var hour in hours)
    {
        var mod = hour % 24;
        if (mod != 0 && freq.ContainsKey(24 - mod))
            res += freq[24 - mod];
        else if (mod == 0 && freq.ContainsKey(mod))
            res += freq[mod];
        if (!freq.ContainsKey(mod))
            freq[mod] = 0;
        freq[mod]++;
    }
    return res;
}