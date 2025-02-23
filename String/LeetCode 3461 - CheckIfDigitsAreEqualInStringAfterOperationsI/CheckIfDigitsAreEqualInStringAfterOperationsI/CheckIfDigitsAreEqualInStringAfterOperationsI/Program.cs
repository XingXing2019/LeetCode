using System.Text;

bool HasSameDigits(string s)
{
    while (s.Length > 2)
    {
        var temp = new StringBuilder();
        for (int i = 0; i < s.Length - 1; i++)
            temp.Append((s[i] - '0' + s[i + 1] - '0') % 10);
        s = temp.ToString();
    }
    return s[0] == s[1];
}