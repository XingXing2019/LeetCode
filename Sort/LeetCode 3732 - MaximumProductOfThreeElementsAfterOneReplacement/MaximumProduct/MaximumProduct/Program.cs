long MaxProduct(int[] nums)
{
    Array.Sort(nums);
    var prod = 1_000_00L;
    var op1 = Math.Abs((long)nums[0] * nums[1] * prod);
    var op2 = Math.Abs((long)nums[^1] * nums[^2] * prod);
    var op3 = Math.Abs((long)nums[0] * nums[^1] * prod);
    return Math.Max(op1, Math.Max(op2, op3));
}