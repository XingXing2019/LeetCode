int[] nums = { 5, 5, 4 };
var k = 5;
Console.WriteLine(MinLength(nums, k));

int MinLength(int[] nums, int k)
{
    var freq = new Dictionary<int, int>();
    int li = 0, hi = 0, sum = 0, res = int.MaxValue;
    while (hi < nums.Length)
    {
        if (!freq.ContainsKey(nums[hi]))
        {
            freq[nums[hi]] = 0;
            sum += nums[hi];
        }
        freq[nums[hi]]++;
        while (li <= hi && sum >= k)
        {
            res = Math.Min(res, hi - li + 1);
            freq[nums[li]]--;
            if (freq[nums[li]] == 0)
            {
                freq.Remove(nums[li]);
                sum -= nums[li];
            }
            li++;
        }
        hi++;
    }
    return res == int.MaxValue ? -1 : res;
}