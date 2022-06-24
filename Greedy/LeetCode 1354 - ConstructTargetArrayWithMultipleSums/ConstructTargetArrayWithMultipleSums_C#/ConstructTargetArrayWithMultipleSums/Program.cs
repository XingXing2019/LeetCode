int[] target = { 8, 5 };
Console.WriteLine(IsPossible_Heap(target));

bool IsPossible_Heap(int[] target)
{
    var maxHeap = new PriorityQueue<int, int>();
    long sum = 0;
    foreach (var num in target)
    {
        maxHeap.Enqueue(num, -num);
        sum += num;
    }
    while (sum != target.Length)
    {
        var max = maxHeap.Dequeue();
        var rest = sum - max;
        if (rest >= max || rest == 0)
            return false;
        var pre = (int)(max % rest);
        if (pre == 0)
            return rest == 1;
        maxHeap.Enqueue(pre, -pre);
        sum = rest + pre;
    }
    return true;
}

bool IsPossible_BinarySearch(int[] target)
{
    long sum = 0;
    var heap = new List<long>();
    foreach (var num in target)
    {
        sum += num;
        heap.Add(num);
    }
    heap.Sort();
    sum -= heap[^1];
    while (heap[^1] != 1)
    {
        long max = heap[^1];
        heap.RemoveAt(heap.Count - 1);
        if (sum == 0 || max <= sum) return false;
        max %= sum;
        if (max < heap[^1])
            sum = sum - heap[^1] + max;
        int index = heap.BinarySearch(max);
        if (index < 0) index = ~index;
        heap.Insert(index, max);
    }
    return true;
}