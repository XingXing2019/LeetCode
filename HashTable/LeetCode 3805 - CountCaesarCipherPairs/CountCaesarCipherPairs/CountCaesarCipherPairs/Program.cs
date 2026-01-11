string[] words = { "ab", "aa", "za", "aa" };
Console.WriteLine(CountPairs(words));

long CountPairs(string[] words)
{
    var res = 0L;
    var freq = words.GroupBy(Reduce).ToDictionary(x => x.Key, x => x.Count());
    foreach (var count in freq.Values.Where(x => x > 1))
        res += (long)count * (count - 1) / 2;
    return res;
}

string Reduce(string word)
{
    var letters = new List<char>();
    var count = word[0] - 'a';
    foreach (var l in word)
    {
        var letter = l - count;
        if (letter < 'a')
            letter += 26;
        letters.Add((char)letter);
    }
    return string.Join("", letters);
}