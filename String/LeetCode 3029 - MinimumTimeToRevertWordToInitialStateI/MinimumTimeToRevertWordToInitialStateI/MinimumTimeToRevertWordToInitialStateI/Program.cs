var word = "abacabc";
var k = 3;
Console.WriteLine(MinimumTimeToInitialState(word, k));

int MinimumTimeToInitialState(string word, int k)
{
    var res = 0;
    var cur = word;
    while (cur.Length >= k)
    {
        cur = cur.Substring(k);
        res++;
        if (word.StartsWith(cur))
            return res;
    }
    return res + 1;
}