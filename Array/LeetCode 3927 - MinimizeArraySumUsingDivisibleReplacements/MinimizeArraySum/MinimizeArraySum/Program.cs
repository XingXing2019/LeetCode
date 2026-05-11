int[] nums = { 3, 6, 2 };
Console.WriteLine(MinArraySum(nums));

long MinArraySum(int[] nums)
{
    var max = nums.Max();
    var min = nums.Min();
    if (min == 1) return nums.Length;
    var dp = new long[max + 1];
    for (int i = 0; i < dp.Length; i++)
        dp[i] = i;
    Array.Sort(nums);
    foreach (var num in nums)
    {
        if (dp[num] != num) continue;
        for (int i = 1; i * num <= max; i++)
        {
            if (dp[i * num] != i * num) continue;
            dp[i * num] = num;
        }
    }
    return nums.Sum(x => dp[x]);
}