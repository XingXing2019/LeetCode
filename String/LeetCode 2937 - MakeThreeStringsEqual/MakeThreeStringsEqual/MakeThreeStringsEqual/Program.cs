int FindMinimumOperations(string s1, string s2, string s3)
{
    var minLen = Math.Min(s1.Length, Math.Min(s2.Length, s3.Length));
    var res = s1.Length + s2.Length + s3.Length - minLen * 3;
    s1 = s1.Substring(0, minLen);
    s2 = s2.Substring(0, minLen);
    s3 = s3.Substring(0, minLen);
    while (s1.Length != 0 && (s1 != s2 || s1 != s3 || s2 != s3))
    {
        s1 = s1.Substring(0, s1.Length - 1);
        s2 = s2.Substring(0, s2.Length - 1);
        s3 = s3.Substring(0, s3.Length - 1);
        res += 3;
    }
    return s1 == string.Empty ? -1 : res;
}