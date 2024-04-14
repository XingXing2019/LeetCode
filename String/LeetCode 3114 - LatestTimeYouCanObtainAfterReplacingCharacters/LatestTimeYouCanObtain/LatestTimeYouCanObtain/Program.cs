var s = "?1:?6";
Console.WriteLine(FindLatestTime(s));
string FindLatestTime(string s)
{
    var res = "";
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == '?')
        {
            if (i == 0)
                res += s[1] == '?' || s[1] - '0' < 2 ? '1' : '0';
            else if (i == 1)
                res += res[0] == '1' ? '1' : '9';
            else if (i == 3)
                res += '5';
            else
                res += '9';
        }
        else
            res += s[i];
    }
    return res;
}