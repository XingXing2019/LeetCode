int[] nums = { 7, 13, 20, 19, 19, 2 };
var k = 2;
Console.WriteLine(MaxSumOfThreeSubarrays(nums, k));

int[] MaxSumOfThreeSubarrays(int[] nums, int k)
{
    var prefix = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
        prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
    int[] leftMax = new int[nums.Length], leftIndex = new int[nums.Length];
    int max = 0, index = 0;
    for (int i = 0; i <= nums.Length - k; i++)
    {
        var sum = prefix[i + k - 1] - (i == 0 ? 0 : prefix[i - 1]);
        if (sum > max)
        {
            max = sum;
            index = i;
        }
        leftMax[i] = max;
        leftIndex[i] = index;
    }
    int[] rightMax = new int[nums.Length], rightIndex = new int[nums.Length];
    max = 0; index = nums.Length - 1;
    for (int i = nums.Length - k; i >= 0; i--)
    {
        var sum = prefix[i + k - 1] - (i == 0 ? 0 : prefix[i - 1]);
        if (sum >= max)
        {
            max = sum;
            index = i;
        }
        rightMax[i] = max;
        rightIndex[i] = index;
    }
    max = 0;
    var res = new int[3];
    for (int i = k; i <= nums.Length - 2 * k; i++)
    {
        var sum = prefix[i + k - 1] - prefix[i - 1];
        if (leftMax[i - k] + sum + rightMax[i + k] > max)
        {
            max = leftMax[i - k] + sum + rightMax[i + k];
            res = new int[] { leftIndex[i - k], i, rightIndex[i + k] };
        }
    }
    return res;
}