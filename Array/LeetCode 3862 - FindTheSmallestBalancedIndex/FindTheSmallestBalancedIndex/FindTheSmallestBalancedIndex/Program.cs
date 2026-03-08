int[] nums = { 999, 818, 984, 995, 841, 822, 984, 978, 960, 997, 896, 926, 759, 961, 1000, 562, 1, 1, 1, 87, 4, 1, 40 };
Console.WriteLine(SmallestBalancedIndex(nums));

int SmallestBalancedIndex(int[] nums)
{
    var prefixSum = new long[nums.Length];
    for (int i = 0; i < nums.Length; i++)
        prefixSum[i] = i == 0 ? nums[i] : nums[i] + prefixSum[i - 1];
    var prod = 1L;
    var res = -1;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        var sum = prefixSum[i] - nums[i];
        if (sum == prod) res = i;
        prod *= nums[i];
        if (prod > prefixSum[^1]) break;
    }
    return res;
}