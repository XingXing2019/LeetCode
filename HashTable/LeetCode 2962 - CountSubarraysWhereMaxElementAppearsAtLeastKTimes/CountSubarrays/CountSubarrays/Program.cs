int[] nums = { 1, 3, 2, 3, 3, 2, 3 };
var k = 2;
Console.WriteLine(CountSubarrays(nums, k));

long CountSubarrays(int[] nums, int k)
{
    int max = nums.Max(), count = 0, last = 0;
    var freq = new Dictionary<int, int>();
    long res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] != max) 
            res += last;
        else
        {
            count++;
            freq[count] = i;
            if (!freq.ContainsKey(count - k + 1)) 
                continue;
            res += freq[count - k + 1] + 1;
            last = freq[count - k + 1] + 1;
        }
    }
    return res;
}