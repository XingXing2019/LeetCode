using System.Text;

string SmallestPalindrome(string s)
{
    var freq = new int[26];
    for (int i = 0; i < s.Length; i++)
        freq[s[i] - 'a']++;
    var front = new List<string>();
    var back = new List<string>();
    var mid = "";
    for (int i = 0; i < 26; i++)
    {
        if (freq[i] % 2 != 0)
            mid = ((char)(i + 'a')).ToString();
        var count = freq[i] / 2;
        var str = new string((char)(i + 'a'), count);
        front.Add(str);
        back.Add(str);
    }
    var res = new StringBuilder();
    for (int i = 0; i < front.Count; i++)
        res.Append(front[i]);
    res.Append(mid);
    for (int i = back.Count - 1; i >= 0; i--)
        res.Append(back[i]);
    return res.ToString();
}