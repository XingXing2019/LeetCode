using System.Text;

string ReverseByType(string s)
{
    var letters = new List<char>();
    var chars = new List<char>();
    foreach (var l in s)
    {
        if (char.IsLetter(l))
            letters.Add(l);
        else
            chars.Add(l);
    }
    var res = new StringBuilder();
    int p1 = letters.Count - 1, p2 = chars.Count - 1;
    foreach (var l in s)
        res.Append(char.IsLetter(l) ? letters[p1--] : chars[p2--]);
    return res.ToString();
}