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