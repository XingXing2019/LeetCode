int[] RotateElements(int[] nums, int k)
{
    var nonNeg = nums.Where(x => x >= 0).ToArray();
    if (nonNeg.Length == 0) return nums;
    k %= nonNeg.Length;
    var rotated = new int[nonNeg.Length];
    for (int i = 0; i < rotated.Length; i++)
        rotated[i] = nonNeg[(i + k) % nonNeg.Length];
    var index = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] < 0) continue;
        nums[i] = rotated[index++];
    }
    return nums;
}