int[] nums = { 2 };
var p = 7;
int[][] queries = new int[][]
{
    new[] { 3, 1 },
    new[] { 1, 2 },
};
Console.WriteLine(PowerUpdate(nums, p, queries));

IList<int> PowerUpdate(int[] nums, int p, int[][] queries)
{
    var minHeap = new PriorityQueue<int, int>();
    var maxHeap = new PriorityQueue<int, int>();
    foreach (var num in nums)
        minHeap.Enqueue(num, num);
    var res = new int[queries.Length];
    long mod = 1_000_000_000 + 7;
    var count = nums.Length;
    for (int i = 0; i < queries.Length; i++)
    {
        int val = queries[i][0], k = queries[i][1];
        minHeap.Enqueue(val, val);
        count++;
        while (maxHeap.Count >= count - k && maxHeap.Count != 0)
        {
            var max = maxHeap.Dequeue();
            minHeap.Enqueue(max, max);
        }
        while (minHeap.Count != 0 && minHeap.Count > k)
        {
            var min = minHeap.Dequeue();
            maxHeap.Enqueue(min, -min);
        }
        var b = minHeap.Peek();
        p = (int)GetPower(p, b, mod);
        res[i] = p;
    }
    return res;
}

long GetPower(long a, long b, long mod)
{
    if (b == 0) return 1 % mod;
    var pow = GetPower(a, b / 2, mod);
    return b % 2 == 0 ? pow * pow % mod : (pow * pow % mod * (a % mod)) % mod;
}