bool CanAliceWin(int[] nums)
{
    var a = nums.Where(x => x < 10).Sum();
    var b = nums.Sum() - a;
    return a != b;
}