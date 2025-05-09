int[] forward = { 1, 4, 4 };
int[] backward = { 4, 1, 2 };
int[] queries = { 1, 2, 0, 2 };
Console.WriteLine(MinTotalTime(forward, backward, queries));

long MinTotalTime(int[] forward, int[] backward, int[] queries)
{
    var n = forward.Length;
    var prefix = new long[n];
    var suffix = new long[n];
    for (int i = 0; i < n; i++)
        prefix[i] = i == 0 ? forward[i] : prefix[i - 1] + forward[i];
    for (int i = n - 1; i >= 0; i--)
        suffix[i] = i == n - 1 ? backward[i] : suffix[i + 1] + backward[i];
    var res = 0L;
    for (int i = 0; i < queries.Length; i++)
    {
        int start = i == 0 ? 0 : queries[i - 1], end = queries[i];
        var moveForward = end > start
            ? (end == 0 ? 0 : prefix[end - 1]) - (start == 0 ? 0 : prefix[start - 1])
            : (end == 0 ? 0 : prefix[end - 1]) + prefix[n - 2] - (start == 0 ? 0 : prefix[start - 1]) + forward[^1];
        var moveBackward = end < start
            ? (end == n - 1 ? 0 : suffix[end + 1])  - (start == n - 1 ? 0 : suffix[start + 1])
            : suffix[1] - (start == n - 1 ? 0 : suffix[start + 1])  + (end == n - 1 ? 0 : suffix[end + 1]) + backward[0];
        res += Math.Min(moveForward, moveBackward);
    }
    return res;
}