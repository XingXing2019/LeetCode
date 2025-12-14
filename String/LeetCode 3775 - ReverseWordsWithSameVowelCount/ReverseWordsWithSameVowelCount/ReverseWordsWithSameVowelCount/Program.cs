using System.Text;

string ReverseWords(string s)
{
    var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
    var words = s.Split(' ');
    var first = 0;
    for (var i = 0; i < words.Length; i++)
    {
        var count = 0;
        var temp = new StringBuilder();
        for (int j = words[i].Length - 1; j >= 0; j--)
        {
            if (vowels.Contains(words[i][j]))
                count++;
            temp.Append(words[i][j]);
        }
        if (i == 0)
            first = count;
        else if (count == first)
            words[i] = temp.ToString();
    }
    return string.Join(' ', words);
}