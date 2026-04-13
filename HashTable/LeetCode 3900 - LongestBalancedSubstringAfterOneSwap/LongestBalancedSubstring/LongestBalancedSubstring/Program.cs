var s = "10000011";
Console.WriteLine(LongestBalanced(s));

int LongestBalanced(string s)
{
    var hasPrefixZero = new bool[s.Length];
    var hasPrefixOne = new bool[s.Length];
    var hasSuffixZero = new bool[s.Length];
    var hasSuffixOne = new bool[s.Length];
    bool prefixZero = false, prefixOne = false;
    bool suffixZero = false, suffixOne = false;
    for (int i = 0; i < s.Length; i++)
    {
        hasPrefixZero[i] = prefixZero;
        hasPrefixOne[i] = prefixOne;
        prefixZero |= s[i] == '0';
        prefixOne |= s[i] == '1';
        hasSuffixZero[^(i + 1)] = suffixZero;
        hasSuffixOne[^(i + 1)] = suffixOne;
        suffixZero |= s[^(i + 1)] == '0';
        suffixOne |= s[^(i + 1)] == '1';
    }
    int sum = 0, res = 0, firstZero = -1, firstOne = -1;
    var dict = new Dictionary<int, int>();
    for (int i = 0; i < s.Length; i++)
    {
        if (!dict.ContainsKey(sum))
            dict[sum] = i;
        sum += s[i] == '1' ? 1 : -1;
        if (sum == 0 && firstZero == -1) firstZero = i;
        if (sum == 0 && firstOne == -1) firstOne = i;
        if (dict.ContainsKey(sum))
            res = Math.Max(res, i - dict[sum] + 1);
        if (dict.ContainsKey(sum - 2))
        {
            var index = dict[sum - 2];
            if (hasPrefixZero[index] || hasSuffixZero[i])
            {
                res = Math.Max(res, i - index + 1);
            }
            if (sum - 2 == 0 && firstZero != -1 && (hasPrefixZero[firstZero] || hasSuffixZero[i]))
            {
                res = Math.Max(res, i - firstZero);
            }
        }
        if (dict.ContainsKey(sum + 2))
        {
            var index = dict[sum + 2];
            if (hasPrefixOne[index] || hasSuffixOne[i])
            {
                res = Math.Max(res, i - index + 1);
            }
            if (sum + 2 == 0 && firstOne != -1 && (hasPrefixOne[firstOne] || hasSuffixOne[i]))
            {
                res = Math.Max(res, i - firstOne);
            }
        }
    }
    return res;
}