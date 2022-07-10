int FillCups(int[] amount)
{
    var maxHeap = new PriorityQueue<int, int>();
    foreach (var a in amount)
    {
        if (a == 0) continue;
        maxHeap.Enqueue(a, -a);
    }
    var res = 0;
    while (maxHeap.Count != 0)
    {
        var max = maxHeap.Dequeue();
        var secMax = maxHeap.Count != 0 ? maxHeap.Dequeue() : 0;
        max--;
        secMax--;
        res++;
        if (max > 0)
            maxHeap.Enqueue(max, -max);
        if (secMax > 0)
            maxHeap.Enqueue(secMax, -secMax);
    }
    return res;
}