using System.Text;

string GetEncryptedString(string s, int k)
{
    var res = new StringBuilder();
    for (int i = 0; i < s.Length; i++)
        res.Append(s[(i + k) % s.Length]);
    return res.ToString();
}