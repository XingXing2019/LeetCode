int[] nums = { 4, 5, 2, 8, 9, 1, 3 };
Console.WriteLine(MaxScore(nums));

long MaxScore(int[] nums)
{
    var suffix = new int[nums.Length][];
    int max = 0, index = nums.Length;
    long res = 0;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        suffix[i] = new[] { index, max };
        max = Math.Max(max, nums[i]);
        if (nums[i] >= max) index = i;
    }
    int cur = 0, next = suffix[0][0];
    while (next < nums.Length)
    {
        res += (long)suffix[cur][1] * (next - cur);
        cur = suffix[cur][0];
        next = suffix[next][0];
    }
    return res;
}