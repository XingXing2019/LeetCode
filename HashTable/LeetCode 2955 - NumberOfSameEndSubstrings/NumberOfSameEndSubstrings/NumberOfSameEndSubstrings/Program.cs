var s = "abcaab";
var queries = new int[][]
{
    new[] { 0, 0 },
    new[] { 1, 4 },
    new[] { 2, 5 },
    new[] { 0, 5 },
};
Console.WriteLine(SameEndSubstringCount(s, queries));

int[] SameEndSubstringCount(string s, int[][] queries)
{
    var freq = new int[s.Length][];
    for (int i = 0; i < s.Length; i++)
    {
        freq[i] = new int[26];
        if (i != 0)
            Array.Copy(freq[i - 1], freq[i], freq[i].Length);
        freq[i][s[i] - 'a']++;
    }
    var res = new int[queries.Length];
    for (int i = 0; i < queries.Length; i++)
    {
        var start = queries[i][0] == 0 ? new int[26] : freq[queries[i][0] - 1];
        var end = freq[queries[i][1]];
        for (int j = 0; j < 26; j++)
        {
            var count = end[j] - start[j];
            res[i] += (1 + count) * count / 2;
        }
    }
    return res;
}