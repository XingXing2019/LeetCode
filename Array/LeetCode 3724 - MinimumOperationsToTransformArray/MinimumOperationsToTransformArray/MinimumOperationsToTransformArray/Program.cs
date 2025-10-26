int[] nums1 = { 7, 3 };
int[] nums2 = { 2, 5, 4 };
Console.WriteLine(MinOperations(nums1, nums2));

long MinOperations(int[] nums1, int[] nums2)
{
    var res = 0L;
    var closest = int.MaxValue;
    var found = false;
    for (int i = 0; i < nums1.Length; i++)
    {
        res += Math.Abs(nums1[i] - nums2[i]);
        if (nums2[^1] <= Math.Max(nums1[i], nums2[i]) && nums2[^1] >= Math.Min(nums1[i], nums2[i]))
            found = true;
        else
            closest = Math.Min(closest, Math.Min(Math.Abs(nums2[^1] - nums1[i]), Math.Abs(nums2[^1] - nums2[i])));
    }
    return found ? res + 1 : res + closest + 1;
}