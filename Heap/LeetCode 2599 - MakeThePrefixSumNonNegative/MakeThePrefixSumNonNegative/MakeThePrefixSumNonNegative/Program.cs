int MakePrefSumNonNegative(int[] nums)
{
    var minHeap = new PriorityQueue<int, int>();
    long prefix = 0;
    var res = 0;
    foreach (var num in nums)
    {
        prefix += num;
        minHeap.Enqueue(num, num);
        if (prefix >= 0)
            continue;
        prefix -= minHeap.Dequeue();
        res++;
    }
    return res;
}