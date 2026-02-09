int[] nums = { 1, 3, 2 };
var k = 4;
Console.WriteLine(CountSubarrays(nums, k));

long CountSubarrays(int[] nums, long k)
{
    long li = 0, hi = 0, res = 0;
    var dict = new SortedList<int, int>();
    while (hi < nums.Length)
    {
        if (!dict.ContainsKey(nums[hi]))
            dict[nums[hi]] = 0;
        dict[nums[hi]]++;
        while (li < hi && (dict.Keys.Max() - dict.Keys.Min()) * (hi - li + 1) > k)
        {
            dict[nums[li]]--;
            if (dict[nums[li]] == 0)
                dict.Remove(nums[li]);
            li++;
        }
        res += hi - li + 1;
        hi++;
    }
    return res;
}