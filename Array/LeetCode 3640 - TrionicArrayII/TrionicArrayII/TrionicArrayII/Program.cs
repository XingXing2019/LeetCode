int[] nums = { 1, 4, 2, 2, 3, 1, 2 };
Console.WriteLine(MaxSumTrionic(nums));

long MaxSumTrionic(int[] nums)
{
    var isDecreasing = nums[1] < nums[0];
    var decreases = new List<long[]>();
    long start = 0, sum = 0, len = 0;
    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i] < nums[i - 1])
        {
            if (!isDecreasing)
                isDecreasing = !isDecreasing;
            sum += nums[i - 1];
            len++;
        }
        else
        {
            if (isDecreasing)
            {
                isDecreasing = !isDecreasing;
                decreases.Add(new []{start, sum + nums[i - 1], len + 1 });
            }
            sum = 0;
            start = i;
            len = 0;
        }
    }
    var res = long.MinValue;
    foreach (var decrease in decreases)
    {
        if (decrease[0] == 0) continue;
        long l = decrease[0] - 2, r = decrease[0] + decrease[2] + 1;
        if (nums[decrease[0] - 1] == nums[decrease[0]] || nums[decrease[0] + decrease[2]] == nums[decrease[0] + decrease[2] - 1]) continue;
        long sumL = nums[decrease[0] - 1], sumR = nums[decrease[0] + decrease[2]], maxL = sumL, maxR = sumR;
        while (l >= 0 && nums[l] < nums[l + 1])
        {
            sumL += nums[l--];
            maxL = Math.Max(maxL, sumL);
        }
        while (r < nums.Length && nums[r] > nums[r - 1])
        {
            sumR += nums[r++];
            maxR = Math.Max(maxR, sumR);
        }
        res = Math.Max(res, decrease[1] + maxL + maxR);
    }
    return res;
}