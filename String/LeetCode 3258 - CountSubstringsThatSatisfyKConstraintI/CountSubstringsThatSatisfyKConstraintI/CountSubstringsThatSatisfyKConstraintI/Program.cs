int CountKConstraintSubstrings(string s, int k)
{
    var res = 0;
    for (int i = 0; i < s.Length; i++)
    {
        int zero = 0, one = 0;
        for (int j = i; j < s.Length; j++)
        {
            zero += s[j] == '0' ? 1 : 0;
            one += s[j] - '0';
            if (zero <= k || one <= k)
                res++;
        }
    }
    return res;
}