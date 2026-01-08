int[] nums1 = { -1, -1 };
int[] nums2 = { 1 };
Console.WriteLine(MaxDotProduct(nums1, nums2));

int MaxDotProduct(int[] nums1, int[] nums2)
{
    var dp = new int[nums1.Length][];
    for (int i = 0; i < dp.Length; i++)
        dp[i] = new int[nums2.Length];
    for (int i = 0; i < dp.Length; i++)
    {
        for (int j = 0; j < dp[i].Length; j++)
        {
            if (i == 0 && j == 0)
                dp[i][j] = nums1[i] * nums2[j];
            else if (i == 0)
                dp[i][j] = Math.Max(dp[i][j - 1], nums1[i] * nums2[j]);
            else if (j == 0)
                dp[i][j] = Math.Max(dp[i - 1][j], nums1[i] * nums2[j]);
            else
                dp[i][j] = Math.Max(Math.Max(0, dp[i - 1][j - 1]) + nums1[i] * nums2[j], Math.Max(dp[i - 1][j], dp[i][j - 1]));
        }
    }
    return dp[^1][^1];
}