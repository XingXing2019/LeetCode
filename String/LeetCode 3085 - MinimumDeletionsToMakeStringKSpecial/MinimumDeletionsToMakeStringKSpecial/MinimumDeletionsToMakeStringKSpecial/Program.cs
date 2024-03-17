var word = "aabcaba";
var k = 0;
Console.WriteLine(MinimumDeletions(word, k));

int MinimumDeletions(string word, int k)
{
    var freq = word.GroupBy(x => x).Select(x => x.Count()).OrderBy(x => x).ToList();
    var prefix = new int[freq.Count];
    for (int i = 0; i < freq.Count; i++)
        prefix[i] = i == 0 ? freq[i] : freq[i] + prefix[i - 1];
    var res = int.MaxValue;
    for (int i = 0; i < freq.Count; i++)
    {
        var remove = i == 0 ? 0 : prefix[i - 1];
        for (int j = i + 1; j < freq.Count; j++)
        {
            if (freq[j] - freq[i] <= k) continue;
            remove += freq[j] - freq[i] - k;
        }
        res = Math.Min(res, remove);
    }
    return res;
}