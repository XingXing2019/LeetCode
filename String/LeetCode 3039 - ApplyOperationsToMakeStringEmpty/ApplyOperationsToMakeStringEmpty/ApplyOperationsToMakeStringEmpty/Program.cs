var s = "aabcbbca";
Console.WriteLine(LastNonEmptyString(s));

string LastNonEmptyString(string s)
{
    var dict = new Dictionary<char, Queue<int>>();
    var max = 0;
    for (int i = 0; i < s.Length; i++)
    {
        if (!dict.ContainsKey(s[i]))
            dict[s[i]] = new Queue<int>();
        dict[s[i]].Enqueue(i);
        max = Math.Max(max, dict[s[i]].Count);
    }
    for (int i = 0; i < max - 1; i++)
    {
        foreach (var l in dict.Keys)
        {
            if (dict[l].Count == 0)
                dict.Remove(l);
            else
                dict[l].Dequeue();
        }
    }
    var indexes = new List<int>();
    foreach (var l in dict.Keys)
        indexes.AddRange(dict[l]);
    indexes.Sort();
    var res = "";
    foreach (var index in indexes)
        res += s[index];
    return res;
}