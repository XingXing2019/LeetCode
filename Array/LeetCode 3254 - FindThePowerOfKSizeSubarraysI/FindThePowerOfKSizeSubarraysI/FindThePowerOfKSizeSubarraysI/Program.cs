int[] nums = { 1, 2, 3, 4, 3, 2, 5 };
var k = 3;
Console.WriteLine(ResultsArray(nums, k));

int[] ResultsArray(int[] nums, int k)
{
    var res = new int[nums.Length - k + 1];
    for (int i = 0; i <= nums.Length - k; i++)
    {
        res[i] = int.MaxValue;
        for (int j = 0; j < k; j++)
        {
            if (j == 0 || nums[i + j] == nums[i + j - 1] + 1) continue;
            res[i] = -1;
        }
        res[i] = Math.Min(res[i], nums[i + k - 1]);
    }
    return res;
}