int[] nums = { 2, 7, 7, 8, 9, 4, 9, 4 };
var k = 9;
Console.WriteLine(MinChanges(nums, k));

int MinChanges(int[] nums, int k)
{
    var freq = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length / 2; i++)
    {
        var diff = Math.Abs(nums[i] - nums[^(i + 1)]);
        if (!freq.ContainsKey(diff))
            freq[diff] = 0;
        freq[diff]++;
    }
    var values = freq.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Select(x => x.Key).ToList();
    var max = values[0];
    return Count(nums, max, k);
}


int Count(int[] nums, int target, int k)
{
    var res = 0;
    for (int i = 0; i < nums.Length / 2; i++)
    {
        var diff = Math.Abs(nums[i] - nums[^(i + 1)]);
        if (diff == target) continue;
        if (nums[i] - target <= k || nums[^(i + 1)] - target <= k)
            res++;
        else
            res += 2;
    }
    return res;
}