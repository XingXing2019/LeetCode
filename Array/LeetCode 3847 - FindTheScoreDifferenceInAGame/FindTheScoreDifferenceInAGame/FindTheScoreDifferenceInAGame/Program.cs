int ScoreDifference(int[] nums)
{
    int res = 0, turn = 1;
    for (int i = 0; i < nums.Length; i++)
    {
        if ((i + 1) % 6 == 0)
            turn *= -1;
        if (nums[i] % 2 != 0)
            turn *= -1;
        res += nums[i] * turn;
    }
    return res;
}