int[] nums = { 2, 5, 6, 8, 5 };
var k = 4;
Console.WriteLine(MinOperationsToMakeMedianK(nums, k));

long MinOperationsToMakeMedianK(int[] nums, int k)
{
    Array.Sort(nums);
    var index = nums.Length / 2;
    long res = Math.Abs(k - nums[index]);
    if (nums[index] > k)
    {
        for (int i = 0; i < index; i++)
        {
            res += Math.Max(0, nums[i] - k);
        }
    }
    else
    {
        for (int i = index + 1; i < nums.Length; i++)
        {
            res += Math.Max(0, k - nums[i]);
        }
    }
    return res;
}