int[] nums = { 1, 1, 1 };
int[][] queries = new[]
{
    new[] { 0, 2, 1, 4 }
};
Console.WriteLine(XorAfterQueries(nums, queries));

int XorAfterQueries(int[] nums, int[][] queries)
{
    int mod = 1_000_000_000 + 7, res = 0;
    var copy = nums.Select(x => (long)x).ToArray();
    foreach (var query in queries)
    {
        int l = query[0], r = query[1], k = query[2], v = query[3];
        for (int i = l; i <= r; i += k)
        {
            copy[i] = (copy[i] * v) % mod;
        }
    }
    foreach (var num in copy)
        res ^= num;
    return res;
}