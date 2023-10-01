int[] nums = { 2, 1, 5, 7, 7, 1, 6, 3 };
var target = 39;
Console.WriteLine(MinSizeSubarray(nums, target));

int MinSizeSubarray(int[] nums, int target)
{
    long total = 0, longTarget = target;
    foreach (var num in nums)
        total += num;
    var count = longTarget / total;
    longTarget %= total;
    if (longTarget == 0) return (int)count * nums.Length;
    var doubleNums = new long[nums.Length * 2];
    for (int i = 0; i < nums.Length; i++)
        doubleNums[i] = doubleNums[i + nums.Length] = nums[i];
    int li = 0, hi = 0, res = int.MaxValue;
    long sum = 0;
    while (hi < doubleNums.Length)
    {
        sum += doubleNums[hi];
        while (li < hi && sum > longTarget)
            sum -= doubleNums[li++];
        if (sum == longTarget)
            res = Math.Min(res, hi - li + 1);
        hi++;
    }
    return res == int.MaxValue ? -1 : res + (int)count * nums.Length;
}