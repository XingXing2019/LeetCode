int[] nums1 = { 4, 6, 3, 1, 4, 2, 10, 9, 5 };
int[] nums2 = { 5, 10, 3, 2, 6, 1, 9 };
Console.WriteLine(MinimumAddedInteger(nums1, nums2));

int MinimumAddedInteger(int[] nums1, int[] nums2)
{
    Array.Sort(nums1);
    Array.Sort(nums2);
    var res = int.MaxValue;
    for (int i = 0; i < nums1.Length; i++)
    {
        for (int j = i + 1; j < nums1.Length; j++)
        {
            res = Math.Min(res, GetVariable(nums1, i, j, nums2));
        }
    }
    return res;
}

int GetVariable(int[] nums1, int remove1, int remove2, int[] nums2)
{
    var newNums1 = new int[nums1.Length];
    var index = 0;
    for (int i = 0; i < nums1.Length; i++)
    {
        if (i == remove1 || i == remove2) continue;
        newNums1[index++] = nums1[i];
    }
    var diff = nums2[0] - newNums1[0];
    for (int i = 0; i < nums2.Length; i++)
    {
        if (nums2[i] - newNums1[i] != diff)
            return int.MaxValue;
    }
    return diff;
}