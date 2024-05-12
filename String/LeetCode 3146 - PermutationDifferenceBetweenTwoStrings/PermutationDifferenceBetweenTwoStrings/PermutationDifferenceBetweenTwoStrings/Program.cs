int FindPermutationDifference(string s, string t)
{
    var dict = new Dictionary<char, int>();
    for (int i = 0; i < t.Length; i++)
        dict[t[i]] = i;
    var res = 0;
    for (int i = 0; i < s.Length; i++)
        res += Math.Abs(i - dict[s[i]]);
    return res;
}