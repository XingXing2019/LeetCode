string MaximumXor(string s, string t)
{
    var one = t.Count(x => x == '1');
    var zero = t.Length - one;
    var digits = new char[s.Length];
    Array.Fill(digits, '0');
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == '1' && zero != 0)
        {
            digits[i] = '1';
            zero--;
        }
        else if (s[i] == '0' && one != 0)
        {
            digits[i] = '1';
            one--;
        }
    }
    return string.Join("", digits);
}