int[] nums = { 3, 1, 4, 3, 2, 2, 4 };
var k = 2;
Console.WriteLine(CountGood(nums, k));

long CountGood(int[] nums, int k)
{
    int li = 0, hi = 0, good = 0;
    var freq = new Dictionary<int, int>();
    long res = 0;
    while (li < nums.Length)
    {
        while (hi < nums.Length && good < k)
        {
            good += freq.GetValueOrDefault(nums[hi], 0);
            if (!freq.ContainsKey(nums[hi]))
                freq[nums[hi]] = 0;
            freq[nums[hi++]]++;
        }
        if (good >= k)
            res += nums.Length - hi + 1;
        freq[nums[li]]--;
        good -= freq[nums[li]];
        li++;
    }
    return res;
}