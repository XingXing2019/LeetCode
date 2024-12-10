int[] nums = { -5, 1, 2, -3, 4 };
var k = 2;
Console.WriteLine(MaxSubarraySum(nums, k));

long MaxSubarraySum(int[] nums, int k)
{
    var max = 1_000_000_000_000_000;
    var prefix = new long[k];
    Array.Fill(prefix, max);
    prefix[^1] = 0;
    long res = -max, pre = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        pre += nums[i];
        res = Math.Max(res, pre - prefix[i % k]);
        prefix[i % k] = Math.Min(prefix[i % k], pre);
    }
    return res;
}