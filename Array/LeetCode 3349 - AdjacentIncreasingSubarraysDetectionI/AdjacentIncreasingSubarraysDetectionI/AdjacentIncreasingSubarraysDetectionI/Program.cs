var nums = new List<int> { 2, 7, 8, 9, 2, 3, 4 };
var k = 3;
Console.WriteLine(HasIncreasingSubarrays(nums, k));

bool HasIncreasingSubarrays(IList<int> nums, int k)
{
    for (int i = 0; i <= nums.Count - 2 * k; i++)
    {
        var isIncreasing = true;
        for (int j = 1; j < k; j++)
        {
            if (nums[i + j] <= nums[i + j - 1] || nums[i + j + k] <= nums[i + j + k - 1])
            {
                isIncreasing = false;
                break;
            }
        }
        if (isIncreasing) return true;
    }
    return false;
}