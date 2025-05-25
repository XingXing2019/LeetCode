int[] nums = { 1, 3, 2, 4, 5 };
var k = 3;
Console.WriteLine(MinSubarraySort(nums, k));

int[] MinSubarraySort(int[] nums, int k)
{
    var res = new int[nums.Length - k + 1];
    for (int i = 0; i <= nums.Length - k; i++)
        res[i] = GetCount(nums, i, i + k - 1);
    return res;
}

int GetCount(int[] nums, int li, int hi)
{
    int start = -1, end = -1;
    var copy = new int[hi - li + 1];
    for (int i = li; i <= hi; i++)
        copy[i - li] = nums[i];
    var sorted = copy.OrderBy(x => x).ToArray();
    for (int i = 0; i < copy.Length; i++)
    {
        if (copy[i] != sorted[i] && start == -1)
            start = i;
        if (copy[^(i + 1)] != sorted[^(i + 1)] && end == -1)
            end = copy.Length - i - 1;
    }
    return start == -1 ? 0 : end - start + 1;
}