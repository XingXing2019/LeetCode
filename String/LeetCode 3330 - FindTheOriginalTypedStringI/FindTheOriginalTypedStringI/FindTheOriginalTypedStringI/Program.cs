int PossibleStringCount(string word)
{
    int res = 0, count = 0;
    var cur = word[0];
    foreach (var l in word)
    {
        if (l == cur)
            count++;
        else
        {
            cur = l;
            res += count - 1;
            count = 1;
        }
    }
    return res + count;
}