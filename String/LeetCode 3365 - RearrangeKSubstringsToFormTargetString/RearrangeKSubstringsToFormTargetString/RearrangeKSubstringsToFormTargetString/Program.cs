var s = "aabbcc";
var t = "bbaacc";
var k = 2;
Console.WriteLine(IsPossibleToRearrange(s, t, k));

bool IsPossibleToRearrange(string s, string t, int k)
{
    var len = s.Length / k;
    var words = new Dictionary<string, int>();
    for (int i = 0; i < s.Length; i += len)
    {
        var word = s.Substring(i, len);
        words[word] = words.GetValueOrDefault(word) + 1;
    }
    for (int i = 0; i < t.Length; i += len)
    {
        var word = t.Substring(i, len);
        if (!words.ContainsKey(word))
            return false;
        words[word]--;
        if (words[word] == 0)
            words.Remove(word);
    }
    return true;
}