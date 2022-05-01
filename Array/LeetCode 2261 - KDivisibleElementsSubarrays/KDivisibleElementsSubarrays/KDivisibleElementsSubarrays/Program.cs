int[] nums = { 2, 3, 3, 2, 2 };
int k = 2, p = 2;
Console.WriteLine(CountDistinct(nums, k, p));

int CountDistinct(int[] nums, int k, int p)
{
    var set = new HashSet<string>();
    for (int i = 0; i < nums.Length; i++)
    {
        var arr = new List<int>();
        var count = 0;
        for (int j = i; j < nums.Length; j++)
        {
            arr.Add(nums[j]);
            if (nums[j] % p == 0) count++;
            if (count > k) break;
            set.Add(string.Join(":", arr));
        }
    }
    return set.Count;
}