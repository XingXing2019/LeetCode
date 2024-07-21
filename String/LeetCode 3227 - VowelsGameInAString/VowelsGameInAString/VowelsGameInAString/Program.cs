bool DoesAliceWin(string s)
{
    var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
    var count = s.Count(x => vowels.Contains(x));
    return count % 2 != 0 || count != 0;
}