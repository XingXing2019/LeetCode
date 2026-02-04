int[] nums = { 1, 1, 1, 1, 1 };
Console.WriteLine(MinimumK(nums));

int MinimumK(int[] nums)
{
    int li = 1, hi = int.MaxValue;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (IsValid(nums, mid))
            hi = mid - 1;
        else
            li = mid + 1;
    }
    return li;
}

bool IsValid(int[] nums, int k)
{
    var count = 0;
    foreach (var num in nums)
        count += num % k == 0 ? num / k : num / k + 1;
    return count <= (long)k * k;
}