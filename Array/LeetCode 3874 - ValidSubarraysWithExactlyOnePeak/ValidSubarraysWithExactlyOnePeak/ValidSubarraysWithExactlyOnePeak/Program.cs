int[] nums = { -12, 20, -20, 15, -12 };
var k = 2;
Console.WriteLine(ValidSubarrays(nums, k));

long ValidSubarrays(int[] nums, int k)
{
    var peaks = new List<int> { -1 };
    for (int i = 1; i < nums.Length - 1; i++)
    {
        if (nums[i - 1] >= nums[i] || nums[i] <= nums[i + 1]) continue;
        peaks.Add(i);
    }
    peaks.Add(nums.Length);
    var res = 0L;
    for (int i = 1; i < peaks.Count - 1; i++)
    {
        long li = Math.Min(peaks[i] - peaks[i - 1], k + 1);
        long hi = Math.Min(peaks[i + 1] - peaks[i], k + 1);
        res += li * hi;
    }
    return res;
}