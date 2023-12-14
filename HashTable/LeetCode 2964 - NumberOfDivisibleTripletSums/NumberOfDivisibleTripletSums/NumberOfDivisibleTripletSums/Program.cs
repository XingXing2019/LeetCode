int[] nums = { 3, 3, 3 };
var d = 3;
Console.WriteLine(DivisibleTripletCount(nums, d));
int DivisibleTripletCount(int[] nums, int d)
{
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
        res += Count(nums, i, d);
    return res;
}

int Count(int[] nums, int start, int d)
{
    var dict = new Dictionary<int, int>();
    var res = 0;
    for (int i = start; i < nums.Length; i++)
    {
        var mod = nums[i] % d;
        var target = (d - (nums[start] % d + mod) % d) % d;
        if (dict.ContainsKey(target))
            res += nums[start] % d == target ? dict[target] - 1 : dict[target];
        if (!dict.ContainsKey(mod))
            dict[mod] = 0;
        dict[mod]++;
    }
    return res;
}