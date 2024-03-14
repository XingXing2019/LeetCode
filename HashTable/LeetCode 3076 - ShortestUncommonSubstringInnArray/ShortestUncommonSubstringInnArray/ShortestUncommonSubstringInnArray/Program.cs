string[] ShortestSubstrings(string[] arr)
{
    var substrings = new HashSet<string>[arr.Length];
    var res = new string[arr.Length];
    for (int i = 0; i < arr.Length; i++)
        substrings[i] = GetSubstrings(arr[i]);
    for (int i = 0; i < substrings.Length; i++)
        res[i] = GetShortestNonOccur(substrings, i);
    return res;
}

HashSet<string> GetSubstrings(string word)
{
    var res = new List<string>();
    for (int i = 1; i <= word.Length; i++)
    {
        for (int j = 0; j <= word.Length - i; j++)
        {
            res.Add(word.Substring(j, i));
        }
    }
    return new HashSet<string>(res.OrderBy(x => x.Length).ThenBy(x => x));
}

string GetShortestNonOccur(HashSet<string>[] substrings, int index)
{
    foreach (var word in substrings[index])
    {
        var nonOccur = true;
        for (int i = 0; i < substrings.Length; i++)
        {
            if (i == index) continue;
            if (substrings[i].Contains(word))
            {
                nonOccur = false;
                break;
            }
        }
        if (nonOccur)
            return word;
    }
    return "";
} 