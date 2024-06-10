int ValueAfterKSeconds(int n, int k)
{
    var nums = new long[n];
    var mod = 1_000_000_000 + 7;
    Array.Fill(nums, 1);
    for (int i = 0; i < k; i++)
    {
        for (int j = 0; j < n; j++)
        {
            nums[j] = j == 0 ? 1 : (nums[j] + nums[j - 1]) % mod;
        }
    }
    return (int)(nums[^1] % mod);
}