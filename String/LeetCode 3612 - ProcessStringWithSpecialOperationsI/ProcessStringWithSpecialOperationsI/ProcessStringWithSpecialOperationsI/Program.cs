using System.Text;

string ProcessStr(string s)
{
    var res = new StringBuilder();
    foreach (var l in s)
    {
        if (char.IsLetter(l))
            res.Append(l);
        else if (l == '#')
            res = new StringBuilder(res.ToString() + res);
        else if (l == '%')
            res = new StringBuilder(string.Join("", res.ToString().Reverse()));
        else if (res.Length != 0)
            res.Remove(res.Length - 1, 1);
    }
    return res.ToString();
}