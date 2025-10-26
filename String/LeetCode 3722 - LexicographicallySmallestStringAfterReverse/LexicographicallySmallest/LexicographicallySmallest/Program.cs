var s = "abba";
Console.WriteLine(LexSmallest(s));

string LexSmallest(string s)
{
    var words = new List<string>();
    for (int i = 1; i <= s.Length; i++)
    {
        var word1 = string.Join("", s.Substring(0, i).Reverse()) + s.Substring(i);
        var word2 = s.Substring(0, i) + string.Join("", s.Substring(i).Reverse());
        words.Add(word1);
        words.Add(word2);
    }
    return words.OrderBy(x => x).First();
}