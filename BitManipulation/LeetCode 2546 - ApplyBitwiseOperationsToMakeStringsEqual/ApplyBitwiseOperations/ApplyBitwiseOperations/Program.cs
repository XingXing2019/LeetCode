bool MakeStringsEqual(string s, string target)
{
    return s == target || !(s.All(x => x == '0') || target.All(x => x == '0'));
}