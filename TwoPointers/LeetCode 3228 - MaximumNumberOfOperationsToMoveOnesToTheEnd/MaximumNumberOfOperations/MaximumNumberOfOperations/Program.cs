var s = "1001101";
Console.WriteLine(MaxOperations(s));

int MaxOperations(string s)
{
    int res = 0, one = 0;
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == '1')
            one++;
        else if (i != 0 && s[i - 1] != '0')
            res += one;
    }
    return res;
}