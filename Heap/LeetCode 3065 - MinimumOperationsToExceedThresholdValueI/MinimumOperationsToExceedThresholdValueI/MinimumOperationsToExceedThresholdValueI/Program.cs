int MinOperations(int[] nums, int k)
{
    var res = 0;
    var heap = new PriorityQueue<int, int>();
    foreach (var num in nums)
        heap.Enqueue(num, num);
    while (heap.Peek() < k)
    {
        heap.Dequeue();
        res++;
    }
    return res;
}