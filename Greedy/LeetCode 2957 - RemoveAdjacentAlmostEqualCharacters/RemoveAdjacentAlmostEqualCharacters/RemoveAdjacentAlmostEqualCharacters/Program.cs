using System.Text;

var word = "zyxyxyz";
Console.WriteLine(RemoveAlmostEqualCharacters(word));

int RemoveAlmostEqualCharacters(string word)
{
    var res = 0;
    for (int i = 1; i < word.Length; i++)
    {
        if (Math.Abs(word[i] - word[i - 1]) > 1) 
            continue;
        i++;
        res++;
    }
    return res;
}