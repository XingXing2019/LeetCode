int MinimumLength(string s)
{
    return s.GroupBy(x => x).Select(x => x.Count()).Sum(x => x % 2 == 0 ? 2 : 1);
}