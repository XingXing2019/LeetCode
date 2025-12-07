int[] nums = { 12, 21, 45, 33, 54 };
Console.WriteLine(MinMirrorPairDistance(nums));

int MinMirrorPairDistance(int[] nums)
{
    var dict = new Dictionary<int, int>();
    var res = int.MaxValue;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        var reversed = Reverse(nums[i]);
        if (dict.ContainsKey(reversed))
            res = Math.Min(res, dict[reversed] - i);
        dict[nums[i]] = i;
    }
    return res == int.MaxValue ? -1 : res;
}

int Reverse(int num)
{
    var res = 0;
    while (num != 0)
    {
        res = res * 10 + num % 10;
        num /= 10;
    }
    return res;
}