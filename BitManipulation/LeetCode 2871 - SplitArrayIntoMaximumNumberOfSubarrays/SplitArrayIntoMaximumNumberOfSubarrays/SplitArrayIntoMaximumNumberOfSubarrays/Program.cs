int[] nums = { 0, 1 };
Console.WriteLine(MaxSubarrays(nums));
int MaxSubarrays(int[] nums)
{
    var totalAnd = int.MaxValue;
    foreach (var num in nums)
        totalAnd &= num;
    if (totalAnd != 0) return 1;
    int currentAnd = int.MaxValue, res = 0;
    foreach (var num in nums)
    {
        currentAnd &= num;
        if (currentAnd == totalAnd)
        {
            res++;
            currentAnd = int.MaxValue;
        }
    }
    return res;
}