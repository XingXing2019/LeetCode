int MinimumChairs(string s)
{
    int count = 0, res = 0;
    foreach (var l in s)
    {
        count += l == 'E' ? 1 : -1;
        res = Math.Max(res, count);
    }
    return res;
}