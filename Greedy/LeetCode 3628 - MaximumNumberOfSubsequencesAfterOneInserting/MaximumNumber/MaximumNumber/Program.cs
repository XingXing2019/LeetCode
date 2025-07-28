var s = "LCLTCTL";
Console.WriteLine(NumOfSubsequences(s));

long NumOfSubsequences(string s)
{
    var op1 = $"L{s}";
    var op2 = $"{s}T";
    var op3 = GetInsertC(s);
    long count1 = Count(op1), count2 = Count(op2), count3 = Count(op3);
    return Math.Max(count1, Math.Max(count2, count3));
}

long Count(string s)
{
    var countT = new long[s.Length];
    long t = 0L, res = 0L;
    for (int i = s.Length - 1; i >= 0; i--)
    {
        if (s[i] == 'T') t++;
        else if (s[i] == 'C') countT[i] = t;
    }
    var suffix = new long[s.Length];
    for (int i = countT.Length - 1; i >= 0; i--)
        suffix[i] = i == countT.Length - 1 ? countT[i] : countT[i] + suffix[i + 1];
    for (int i = suffix.Length - 1; i >= 0; i--)
    {
        if (s[i] != 'L') continue;
        res += suffix[i];
    }
    return res;
}

string GetInsertC(string s)
{
    var suffixT = new long[s.Length];
    var prefixL = new long[s.Length];
    int l = 0, t = 0;
    for (int i = 0; i < s.Length; i++)
    {
        l += s[i] == 'L' ? 1 : 0;
        prefixL[i] = l;
        suffixT[^(i + 1)] = t;
        t += s[^(i + 1)] == 'T' ? 1 : 0;
    }
    int index = -1;
    var max = 0L;
    for (int i = 0; i < s.Length; i++)
    {
        var prod = suffixT[i] * prefixL[i];
        if (prod <= max) continue;
        max = prod;
        index = i;
    }
    return index == -1 ? $"C{s}" : $"{s.Substring(0, index + 1)}C{s.Substring(index + 1)}";
}