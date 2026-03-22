int[] nums1 = { 1, 4, 7 };
Console.WriteLine(UniformArray(nums1));

bool UniformArray(int[] nums1)
{
    var odd = new List<int>();
    foreach (var num in nums1)
    {
        if (num % 2 != 0) odd.Add(num);
    }
    odd.Sort();
    return IsValid(nums1, odd, true) || IsValid(nums1, odd, false);
}

bool IsValid(int[] nums, List<int> odd, bool isEven)
{
    foreach (var num in nums)
    {
        if (num % 2 == 0 == isEven) continue;
        var index = odd.BinarySearch(num - 1);
        if (index >= 0) continue;
        index = ~index;
        if (index == 0) return false;
    }
    return true;
}