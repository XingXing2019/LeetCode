bool IsPossibleToSplit(int[] nums)
{
    return nums.GroupBy(x => x).All(x => x.Count() <= 2);
}