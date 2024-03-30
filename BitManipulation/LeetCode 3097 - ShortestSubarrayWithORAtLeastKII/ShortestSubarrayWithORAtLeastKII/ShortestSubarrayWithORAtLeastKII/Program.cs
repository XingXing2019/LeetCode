int[] nums = { 1, 2, 32, 21 };
var k = 55;
Console.WriteLine(MinimumSubarrayLength(nums, k));

int MinimumSubarrayLength(int[] nums, int k)
{
    int li = 0, hi = 0, res = int.MaxValue;
    var mask = new int[32];
    while (hi < nums.Length)
    {
        SetMask(mask, nums[hi], true);
        while (li <= hi && GetMask(mask) >= k)
        {
            res = Math.Min(res, hi - li + 1);
            SetMask(mask, nums[li++], false);
        }
        hi++;
    }
    return res == int.MaxValue ? -1 : res;
}

int GetMask(int[] mask)
{
    var res = 0;
    for (int i = 0; i < mask.Length; i++)
    {
        if (mask[i] == 0) continue;
        res += 1 << i;
    }
    return res;
}

void SetMask(int[] mask, int num, bool increase)
{
    var index = 0;
    while (num != 0)
    {
        if (num % 2 != 0)
            mask[index] = increase ? mask[index] + 1 : mask[index] - 1;
        num /= 2;
        index++;
    }
}