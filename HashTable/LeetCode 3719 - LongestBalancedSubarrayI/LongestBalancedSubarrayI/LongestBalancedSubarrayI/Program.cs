int[] nums = { 10, 6, 10, 7 };
Console.WriteLine(LongestBalanced(nums));

int LongestBalanced(int[] nums)
{
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        var odd = new HashSet<int>();
        var even = new HashSet<int>();
        for (int j = i; j < nums.Length; j++)
        {
            if (nums[j] % 2 == 0)
                even.Add(nums[j]);
            else
                odd.Add(nums[j]);
            if (even.Count != odd.Count)
                continue;
            res = Math.Max(res, j - i + 1);
        }
    }
    return res;
}