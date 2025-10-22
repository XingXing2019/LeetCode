int[] nums = { 1, 4, 5 };
int k = 1, numOperations = 2;
Console.WriteLine(MaxFrequency(nums, k, numOperations));

int MaxFrequency(int[] nums, int k, int numOperations)
{
	var res = 0;
	var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
	Array.Sort(nums);
	foreach (int num in nums)
	{
		var count1 = Count(nums, num - k, k, numOperations, freq);
		var count2 = Count(nums, num, k, numOperations, freq);
		var count3 = Count(nums, num + 1, k, numOperations, freq);
		var counts = new int[] { count1, count2, count3 };
		res = Math.Max(res, counts.Max());
	}
	return res;
}

int Count(int[] nums, int num, int k, int numOperations, Dictionary<int, int> freq)
{
    var li = BinarySearch(nums, num - k, true);
    var hi = BinarySearch(nums, num + k, false);
    var count = Math.Min(hi - li + 1 - freq.GetValueOrDefault(num, 0), numOperations);
    return count + freq.GetValueOrDefault(num, 0);
}

int BinarySearch(int[] nums, int target, bool isLeft)
{
    int li = 0, hi = nums.Length - 1;
	while (li <= hi)
	{
		var mid = li + (hi - li) / 2;
		if (isLeft)
		{
			if (nums[mid] >= target)
				hi = mid - 1;
			else
				li = mid + 1;
		}
		else
		{
			if (nums[mid] <= target)
				li = mid + 1;
			else
				hi = mid - 1;
		}
	}
	return isLeft ? li : hi;
}