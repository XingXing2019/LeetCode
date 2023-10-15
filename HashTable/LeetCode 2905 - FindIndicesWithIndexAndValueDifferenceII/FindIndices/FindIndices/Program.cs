int[] nums = { 1, 2, 3 };
int indexDifference = 2, valueDifference = 4;
Console.WriteLine(FindIndices(nums, indexDifference, valueDifference));

int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
{
    int[] minArr = new int[nums.Length], maxArr = new int[nums.Length];
    int min = int.MaxValue, max = int.MinValue, minIndex = -1, maxIndex = -1;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        if (nums[i] < min)
        {
            min = nums[i];
            minIndex = i;
        }
        if (nums[i] > max)
        {
            max = nums[i];
            maxIndex = i;
        }
        minArr[i] = minIndex;
        maxArr[i] = maxIndex;
    }
    for (int i = 0; i < nums.Length; i++)
    {
        var index = i + indexDifference;
        if (index >= nums.Length)
            continue;
        if (Math.Abs(nums[i] - nums[minArr[index]]) >= valueDifference)
            return new[] { i, minArr[index] };
        if (Math.Abs(nums[i] - nums[maxArr[index]]) >= valueDifference)
            return new[] { i, maxArr[index] };
    }
    return new[] { -1, -1 };
}