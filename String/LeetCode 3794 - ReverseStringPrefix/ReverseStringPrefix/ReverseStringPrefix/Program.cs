using System.Text;

string ReversePrefix(string s, int k)
{
    var res = new StringBuilder();
    for (int i = k - 1; i >= 0; i--)
        res.Append(s[i]);
    for (int i = k; i < s.Length; i++)
        res.Append(s[i]);
    return res.ToString();
}