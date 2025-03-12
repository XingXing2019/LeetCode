using System.Text;

string ApplySubstitutions(IList<IList<string>> replacements, string text)
{
    var dict = new Dictionary<string, string>();
    foreach (var replacement in replacements)
        dict[replacement[0]] = replacement[1];
    return DFS(text, dict);
}

string DFS(string text, Dictionary<string, string> dict)
{
    var res = new StringBuilder();
    var index = 0;
    while (index < text.Length)
    {
        if (text[index] != '%')
            res.Append(text[index]);
        else
        {
            var key = text[index + 1].ToString();
            var value = DFS(dict[key], dict);
            res.Append(value);
            index += 2;
        }
        index++;
    }
    return res.ToString();
}