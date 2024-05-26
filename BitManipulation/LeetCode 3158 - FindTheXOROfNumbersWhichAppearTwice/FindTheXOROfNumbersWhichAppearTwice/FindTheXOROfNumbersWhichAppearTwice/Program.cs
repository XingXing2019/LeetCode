int DuplicateNumbersXOR(int[] nums)
{
    nums = nums.GroupBy(x => x).Where(x => x.Count() == 2).Select(x => x.Key).ToArray();
    var res = 0;
    foreach (var num in nums)
        res ^= num;
    return res;
}