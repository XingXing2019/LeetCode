var s = "01";
Console.WriteLine(MaxActiveSectionsAfterTrade(s));

int MaxActiveSectionsAfterTrade(string s)
{
    int one = 0, zero = 0;
    var zeros = new List<int[]>();
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == '1')
        {
            if (zero != 0)
                zeros.Add(new[] { i - zero, zero });
            zero = 0;
            one++;
        }
        else
            zero++;
    }
    if (zero != 0)
        zeros.Add(new[] { s.Length - zero, zero });
    var res = 0;
    for (int i = 1; i < zeros.Count; i++)
    {
        var convert = zeros[i][1] + zeros[i - 1][1];
        res = Math.Max(res, one + convert);
    }
    return res;
}