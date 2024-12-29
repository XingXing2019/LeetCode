var word = "gh";
var numFriends = 1;
Console.WriteLine(AnswerString(word, numFriends));
string AnswerString(string word, int numFriends)
{
    if (numFriends == 1) return word;
    var res = "";
    for (int i = 0; i < word.Length; i++)
    {
        var len = Math.Min(word.Length - numFriends + 1, word.Length - i);
        var str = word.Substring(i, len);
        if (string.Compare(res, str) < 0)
        {
            res = str;
        }
    }
    return res;
}

int Compare(string word1, string word2)
{
    for (int i = 0; i < Math.Min(word1.Length, word2.Length); i++)
    {
        if (word1[i] == word2[i]) continue;
        return word1[i] - word2[i];
    }
    return word1.Length - word2.Length;
}