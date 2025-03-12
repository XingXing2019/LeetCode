int[] TransformArray(int[] nums)
{
    var res = new int[nums.Length];
    var index = res.Length - 1;
    foreach (var num in nums)
    {
        if (num % 2 == 0) continue;
        res[index--] = 1;
    }
    return res;
}