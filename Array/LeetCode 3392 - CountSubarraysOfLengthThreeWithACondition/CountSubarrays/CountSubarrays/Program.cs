int CountSubarrays(int[] nums)
{
    var res = 0;
	for (int i = 1; i < nums.Length - 1; i++)
	{
		if (2 * (nums[i - 1] + nums[i + 1]) == nums[i])
			res++;
	}
	return res;
}