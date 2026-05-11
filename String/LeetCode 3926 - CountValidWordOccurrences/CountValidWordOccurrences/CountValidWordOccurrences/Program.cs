string[] chunks = { "nn--hl", "c-z-" };
string[] queries = { "hlc-z" };
Console.WriteLine(CountWordOccurrences(chunks, queries));

int[] CountWordOccurrences(string[] chunks, string[] queries)
{
    var s = string.Join("", chunks);
    var freq = new Dictionary<string, int>();
    var letters = new List<char>();
    foreach (var l in s)
    {
        if (char.IsLetter(l))
            letters.Add(l);
        else if (l == ' ')
        {
            if (letters.Count == 0) continue;
            if (letters[^1] == '-')
                letters.RemoveAt(letters.Count - 1);
            Add(freq, letters);
        }
        else
        {
            if (letters.Count == 0) continue;
            if (letters[^1] == '-')
            {
                letters.RemoveAt(letters.Count - 1);
                Add(freq, letters);
                continue;
            }
            letters.Add(l);
        }
    }
    if (letters.Count != 0)
    {
        if (letters[^1] == '-')
            letters.RemoveAt(letters.Count - 1);
        Add(freq, letters);
    }
    var res = new int[queries.Length];
    for (int i = 0; i < queries.Length; i++)
        res[i] = freq.GetValueOrDefault(queries[i], 0);
    return res;
}

void Add(Dictionary<string, int> freq, List<char> letters)
{
    if (letters.Count == 0) return;
    var word = string.Join("", letters);
    if (!freq.ContainsKey(word))
        freq[word] = 0;
    freq[word]++;
    letters.Clear();
}