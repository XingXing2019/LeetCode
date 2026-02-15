using System.Text;

string MapWordWeights(string[] words, int[] weights)
{
    var res = new StringBuilder();
    foreach (var word in words)
    {
        var sum = 0;
        foreach (var l in word)
            sum += weights[l - 'a'];
        var letter = (char)(25 - sum % 26 + 'a');
        res.Append(letter);
    }
    return res.ToString();
}