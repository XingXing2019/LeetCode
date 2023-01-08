long MaxKelements(int[] nums, int k)
{
    var maxHeap = new PriorityQueue<double, double>();
    foreach (var num in nums)
        maxHeap.Enqueue(num, -num);
    double res = 0;
    for (int i = 0; i < k; i++)
    {
        var max = maxHeap.Dequeue();
        res += max;
        max = Math.Ceiling(max / 3);
        maxHeap.Enqueue(max, -max);
    }
    return (long)res;
}