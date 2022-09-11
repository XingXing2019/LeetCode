using System.Diagnostics.CodeAnalysis;

int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
{
    var minHeap = new PriorityQueue<int, int>();
    var engineers = new int[n][];
    for (int i = 0; i < n; i++)
        engineers[i] = new[] { speed[i], efficiency[i] };
    Array.Sort(engineers, (a, b) => b[1] - a[1]);
    long res = 0, sum = 0, mod = 1_000_000_000 + 7;
    foreach (var engineer in engineers)
    {
        sum += engineer[0];
        minHeap.Enqueue(engineer[0], engineer[0]);
        if (minHeap.Count > k)
            sum -= minHeap.Dequeue();
        res = Math.Max(res, sum * engineer[1]);
    }
    return (int) (res % mod);
}