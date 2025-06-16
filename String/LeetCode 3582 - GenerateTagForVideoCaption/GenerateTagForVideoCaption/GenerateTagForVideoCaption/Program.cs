using System.Text;

var caption = "can I Go There";
Console.WriteLine(GenerateTag(caption));

string GenerateTag(string caption)
{
    var words = caption.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var res = new StringBuilder();
    res.Append('#');
    for (int i = 0; i < words.Length; i++)
    {
        var lower = words[i].ToLower();
        var word = new StringBuilder();
        for (int j = 0; j < lower.Length; j++)
        {
            if (!char.IsLetter(lower[j])) continue;
            word.Append(word.Length == 0 && i != 0 ? char.ToUpper(lower[j]) : lower[j]);
        }
        res.Append(word);
    }
    return res.ToString().Substring(0, Math.Min(100, res.Length));
}