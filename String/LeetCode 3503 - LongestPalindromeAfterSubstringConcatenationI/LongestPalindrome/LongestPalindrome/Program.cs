using System.Text;

int LongestPalindrome(string s, string t)
{
    var word1 = GetSubstrings(s);
    var word2 = GetSubstrings(t);
    var res = 0;
    foreach (var w1 in word1)
    {
        foreach (var w2 in word2)
        {
            if (!IsPalindrome(w1 + w2))
                continue;
            res = Math.Max(res, w1.Length + w2.Length);
        }
    }
    return res;
}

List<string> GetSubstrings(string str)
{
    var res = new List<string> { "" };
    for (int i = 0; i < str.Length; i++)
    {
        var substring = new StringBuilder();
        for (int j = i; j < str.Length; j++)
        {
            substring.Append(str[j]);
            res.Add(substring.ToString());
        }
    }
    return res;
}

bool IsPalindrome(string str)
{
    int li = 0, hi = str.Length - 1;
    while (li < hi)
    {
        if (str[li] != str[hi])
            return false;
        li++;
        hi--;
    }
    return true;
}