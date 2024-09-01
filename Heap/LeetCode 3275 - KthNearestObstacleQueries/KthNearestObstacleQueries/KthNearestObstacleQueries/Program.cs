int[] ResultsArray(int[][] queries, int k)
{
    var heap = new PriorityQueue<int, int>();
    var res = new int[queries.Length];
    for (int i = 0; i < queries.Length; i++)
    {
        var dis = Math.Abs(queries[i][0]) + Math.Abs(queries[i][1]);
        heap.Enqueue(dis, -dis);
        if (heap.Count > k)
            heap.Dequeue();
        res[i] = heap.Count == k ? heap.Peek() : -1;
    }
    return res;
}