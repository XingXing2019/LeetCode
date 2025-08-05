int[] nums = { 6, 7, 5, 1 };
Console.WriteLine(IsTrionic(nums));

bool IsTrionic(int[] nums)
{
    var count = 0;
    var increasing = true;
    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i] == nums[i - 1])
            return false;
        if (nums[i] > nums[i - 1])
        {
            if (increasing) continue;
            count++;
            increasing = true;
        }
        else
        {
            if (i == 1) return false;
            if (!increasing) continue;
            count++;
            increasing = false;
        }
    }
    return count == 2;
}