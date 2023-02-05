long PickGifts(int[] gifts, int k)
{
    long res = 0;
    var maxHeap = new PriorityQueue<int, int>();
    foreach (var gift in gifts)
        maxHeap.Enqueue(gift, -gift);
    for (int i = 0; i < k; i++)
    {
        var max = maxHeap.Dequeue();
        max = (int)Math.Sqrt(max);
        maxHeap.Enqueue(max, -max);
    }
    while (maxHeap.Count != 0)
        res += maxHeap.Dequeue();
    return res;
}