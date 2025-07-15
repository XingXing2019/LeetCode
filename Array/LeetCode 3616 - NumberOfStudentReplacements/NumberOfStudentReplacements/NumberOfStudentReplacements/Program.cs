int TotalReplacements(int[] ranks)
{
    var cur = ranks[0];
    var res = 0;
    for (int i = 1; i < ranks.Length; i++)
    {
        if (ranks[i] >= cur) continue;
        cur = ranks[i];
        res++;
    }
    return res;
}