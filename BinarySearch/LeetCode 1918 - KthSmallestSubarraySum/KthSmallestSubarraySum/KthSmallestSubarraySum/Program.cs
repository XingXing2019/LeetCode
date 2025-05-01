int[] nums = { 2, 1, 4 };
var k = 3;
Console.WriteLine(KthSmallestSubarraySum(nums, k));

int KthSmallestSubarraySum(int[] nums, int k)
{
    int li = 1, hi = nums.Sum();
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        var count = Count(nums, mid);
        if (count >= k)
            hi = mid - 1;
        else
            li = mid + 1;
    }
    return li;
}

int Count(int[] nums, int target)
{
    int res = 0, li = 0, hi = 0, sum = 0;
    while (hi < nums.Length)
    {
        sum += nums[hi];
        while (li <= hi && sum > target)
            sum -= nums[li++];
        res += hi - li + 1;
        hi++;
    }
    return res;
}