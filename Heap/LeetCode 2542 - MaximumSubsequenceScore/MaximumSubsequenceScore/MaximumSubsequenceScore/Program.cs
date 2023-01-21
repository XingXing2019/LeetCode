int[] nums1 = { 2, 1, 14, 12 };
int[] nums2 = { 11, 7, 13, 6 };
var k = 3;
Console.WriteLine(MaxScore(nums1, nums2, k));

long MaxScore(int[] nums1, int[] nums2, int k)
{
    var nums = new long[nums1.Length][];
    for (int i = 0; i < nums.Length; i++)
        nums[i] = new long[] { nums1[i], nums2[i] };
    nums = nums.OrderBy(x => x[1]).ToArray();
    var heap = new PriorityQueue<long, long>();
    long res = 0, sum = 0;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        sum += nums[i][0];
        heap.Enqueue(nums[i][0], nums[i][0]);
        if (heap.Count > k)
            sum -= heap.Dequeue();
        nums[i][0] = sum;
    }
    for (int i = 0; i <= nums.Length - k; i++)
        res = Math.Max(res, nums[i][0] * nums[i][1]);
    return res;
}