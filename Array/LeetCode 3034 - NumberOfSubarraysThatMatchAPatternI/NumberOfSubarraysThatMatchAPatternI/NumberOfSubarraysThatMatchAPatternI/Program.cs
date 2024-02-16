int[] nums = { 1, 4, 4, 1, 3, 5, 5, 3 };
int[] pattern = { 1, 0, -1 };
Console.WriteLine(CountMatchingSubarrays(nums, pattern));

int CountMatchingSubarrays(int[] nums, int[] pattern)
{
    var trend = new int[nums.Length - 1];
    int index = 0, res = 0;
    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i] < nums[i - 1])
            trend[index++] = 0;
        else if (nums[i] == nums[i - 1])
            trend[index++] = 1;
        else
            trend[index++] = 2;
    }
    string patternStr = string.Join("", pattern.Select(x => x + 1)), cur = "";
    for (int i = 0; i < patternStr.Length; i++)
        cur += trend[i];
    for (int i = patternStr.Length; i < trend.Length; i++)
    {
        if (cur == patternStr)
            res++;
        cur = cur.Substring(1) + trend[i];
    }
    return cur == patternStr ? res + 1 : res;
}