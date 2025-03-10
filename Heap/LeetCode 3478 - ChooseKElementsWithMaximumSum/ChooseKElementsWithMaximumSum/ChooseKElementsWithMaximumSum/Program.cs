int[] nums1 = { 4, 2, 1, 5, 3 };
int[] nusm2 = { 10, 20, 30, 40, 50 };
var k = 2;
Console.WriteLine(FindMaxSum(nums1, nusm2, k));

long[] FindMaxSum(int[] nums1, int[] nums2, int k)
{
    var combos = new int[nums1.Length][];
    for (int i = 0; i < nums1.Length; i++)
        combos[i] = new[] { nums1[i], nums2[i], i };
    combos = combos.OrderBy(x => x[0]).ToArray();
    var heap = new PriorityQueue<int, int>();
    var res = new long[nums1.Length];
    var sum = 0L;
    var dict = new Dictionary<int, long>();
    foreach (var combo in combos)
    {
        if (heap.Count > k)
            sum -= heap.Dequeue();
        res[combo[2]] = dict.ContainsKey(combo[0]) ? dict[combo[0]] : sum;
        heap.Enqueue(combo[1], combo[1]);
        sum += combo[1];
        dict[combo[0]] = res[combo[2]];
    }
    return res;
}

// 2  1  4  0  3
// 1  2  3  4  5 
// 30 20 50 10 40