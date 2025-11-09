int MinMoves(int[] nums)
{
    var max = nums.Max();
    return nums.Sum(x => max - x);
}