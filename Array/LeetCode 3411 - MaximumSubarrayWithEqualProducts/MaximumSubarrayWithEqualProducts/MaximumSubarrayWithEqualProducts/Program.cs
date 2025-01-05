int MaxLength(int[] nums)
{
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (!IsValid(nums, i, j)) continue;
            res = Math.Max(res, j - i + 1);
        }
    }
    return res;
}

int GCD(int a, int b)
{
    if (a % b == 0)
        return b;
    return GCD(b, a % b);
}

int LCM(int a, int b)
{
    return a * b / GCD(a, b);
}

bool IsValid(int[] nums, int li, int hi)
{
    int gcd = nums[li], lcm = nums[li], prod = 1;
    for (int i = li; i <= hi; i++)
    {
        gcd = GCD(gcd, nums[i]);
        lcm = LCM(lcm, nums[i]);
        prod *= nums[i];
    }        
    return prod == gcd * lcm;
}