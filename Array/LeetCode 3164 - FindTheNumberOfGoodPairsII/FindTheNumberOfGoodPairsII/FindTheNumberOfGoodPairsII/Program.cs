int[] nums1 = { 1, 3, 4 };
int[] nums2 = { 1, 3, 4 };
var k = 1;
Console.WriteLine(NumberOfPairs(nums1, nums2, k));

long NumberOfPairs(int[] nums1, int[] nums2, int k)
{
    var res = 0L;
    var dict = new Dictionary<int, int>();
    foreach (var num in nums2)
    {
        if (!dict.ContainsKey(num * k))
            dict[num * k] = 0;
        dict[num * k]++;
    }
    foreach (var num in nums1)
    {
        for (int i = 1; i <= Math.Sqrt(num); i++)
        {
            if (num % i != 0) continue;
            res += dict.GetValueOrDefault(i, 0);
            if (i != num / i) res += dict.GetValueOrDefault(num / i, 0);
        }   
    }
    return res;
}