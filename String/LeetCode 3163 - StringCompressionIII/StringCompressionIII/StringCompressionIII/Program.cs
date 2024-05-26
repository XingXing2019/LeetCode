using System.Text;

string CompressedString(string word)
{
    var res = new StringBuilder();
    int index = 0, count = 0;
    var cur = word[0];
    while (index < word.Length)
    {
        cur = word[index];
        while (index < word.Length && word[index] == cur && count < 9)
        {
            index++;
            count++;
        }
        res.Append($"{count}{cur}");
        count = 0;
    }
    return res.ToString();
}