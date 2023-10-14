var n = 1;
string[] words = { "c" };
int[] groups = { 0 };
Console.WriteLine(GetWordsInLongestSubsequence(n, words, groups));

IList<string> GetWordsInLongestSubsequence(int n, string[] words, int[] groups)
{
    var res = new List<string> { words[0] };
    for (int i = 1; i < words.Length; i++)
    {
        if (groups[i] != groups[i - 1])
            res.Add(words[i]);
    }
    return res;
}