int ReverseDegree(string s)
{
    var res = 0;
    for (int i = 0; i < s.Length; i++)
        res += (26 - (s[i] - 'a')) * (i + 1);
    return res;
}