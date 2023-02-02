int[] weights = { 1, 3, 5, 1 };
var k = 2;
Console.WriteLine(PutMarbles(weights, k));

long PutMarbles(int[] weights, int k)
{
    var minHeap = new PriorityQueue<long, long>();
    var maxHeap = new PriorityQueue<long, long>();
    for (int i = 1; i < weights.Length; i++)
    {
        var sum = weights[i] + weights[i - 1];
        minHeap.Enqueue(sum, sum);
        maxHeap.Enqueue(sum, -sum);
        if (minHeap.Count == k)
            minHeap.Dequeue();
        if (maxHeap.Count == k)
            maxHeap.Dequeue();
    }
    long max = 0, min = 0;
    while (minHeap.Count != 0)
    {
        max += minHeap.Dequeue();
        min += maxHeap.Dequeue();
    }
    return max - min;
}