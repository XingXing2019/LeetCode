using System.Text;

string MinimizeStringValue(string s)
{
    var heap = new PriorityQueue<char, int>();
    var freq = new int[26];
    var res = new StringBuilder(s);
    int pow = 1_000_00, index = 0, count = 0;
    var candidates = new List<char>();
    for (var i = 0; i < s.Length; i++)
    {
        if (s[i] == '?')
            count++;
        else
            freq[s[i] - 'a']++;
    }
    for (int i = 0; i < 26; i++)
        heap.Enqueue((char)(i + 'a'), freq[i] * pow + i);
    for (int i = 0; i < count; i++)
    {
        var min = heap.Dequeue();
        freq[min - 'a']++;
        heap.Enqueue(min, freq[min - 'a'] * pow + (min - 'a'));
        candidates.Add(min);
    }
    candidates = candidates.OrderBy(x => x).ToList();
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] != '?') continue;
        res[i] = candidates[index++];
    }
    return res.ToString();
}