long MinOperations(int[] nums1, int[] nums2, int k)
{
    long pos = 0, neg = 0;
	for (int i = 0; i < nums1.Length; i++)
	{
		if (k == 0 && nums1[i] != nums2[i])
			return -1;
		var diff = nums1[i] - nums2[i];
		if (k != 0 && diff % k != 0)
			return -1;
		if (diff >= 0)
			pos += diff;
		else
			neg += diff;
	}
	if (pos + neg != 0)
		return -1;
	return k == 0 ? 0 : pos / k;
}