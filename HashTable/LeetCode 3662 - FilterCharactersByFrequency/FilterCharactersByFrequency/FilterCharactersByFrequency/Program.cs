using System.Text;

string FilterCharacters(string s, int k)
{
    var freq = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var res = new StringBuilder();
    foreach (var l in s)
    {
        if (freq[l] >= k) continue;
        res.Append(l);
    }
    return res.ToString();
}