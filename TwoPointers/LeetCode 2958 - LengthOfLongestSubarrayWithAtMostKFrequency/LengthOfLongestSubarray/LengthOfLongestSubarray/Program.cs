int[] nums = { 1, 2, 3, 1, 2, 3, 1, 2 };
var k = 2;
Console.WriteLine(MaxSubarrayLength(nums, k));

int MaxSubarrayLength(int[] nums, int k)
{
    int li = 0, hi = 0, res = 0;
    var freq = new Dictionary<int, int>();
    while (hi < nums.Length)
    {
        if (!freq.ContainsKey(nums[hi]))
            freq[nums[hi]] = 0;
        freq[nums[hi]]++;
        while (li < hi && freq[nums[hi]] > k)
            freq[nums[li++]]--;
        res = Math.Max(res, hi - li + 1);
        hi++;
    }
    return res;
}