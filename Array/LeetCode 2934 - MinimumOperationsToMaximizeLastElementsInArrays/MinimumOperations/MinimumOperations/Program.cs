int[] nums1 = { 17, 13, 19, 9, 6, 14 };
int[] nums2 = { 17, 14, 15, 1, 19, 19 };
Console.WriteLine(MinOperations(nums1, nums2));

int MinOperations(int[] nums1, int[] nums2)
{
    var opt1 = GetOperations(nums1, nums2);
    (nums1[^1], nums2[^1]) = (nums2[^1], nums1[^1]);
    var opt2 = GetOperations(nums1, nums2);
    return opt1 == -1 && opt2 == -1 ? -1 : Math.Min(opt1, opt2 + 1);
}

int GetOperations(int[] nums1, int[] nums2)
{
    var res = 0;
    for (int i = 0; i < nums1.Length; i++)
    {
        if (nums1[i] <= nums1[^1] && nums2[i] <= nums2[^1]) 
            continue;
        if (nums1[i] > nums1[^1] && (nums1[i] > nums2[^1] || nums2[i] > nums1[^1]))
            return -1;
        if (nums2[i] > nums2[^1] && (nums2[i] > nums1[^1] || nums1[i] > nums2[^1]))
            return -1;
        res++;
    }
    return res;
}