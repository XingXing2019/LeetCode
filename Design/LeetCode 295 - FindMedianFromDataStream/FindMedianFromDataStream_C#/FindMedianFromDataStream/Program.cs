var heap = new MedianFinder();
heap.AddNum(1);
heap.AddNum(2);
Console.WriteLine(heap.FindMedian());
heap.AddNum(3);
Console.WriteLine(heap.FindMedian());

public class MedianFinder
{
    PriorityQueue<int, int> minHeap;
    PriorityQueue<int, int> maxHeap;
    public MedianFinder()
    {
        minHeap = new PriorityQueue<int, int>();
        maxHeap = new PriorityQueue<int, int>();
    }

    public void AddNum(int num)
    {
        minHeap.Enqueue(num, num);
        var min = minHeap.Dequeue();
        maxHeap.Enqueue(min, -min);
        if (maxHeap.Count > minHeap.Count)
        {
            var max = maxHeap.Dequeue();
            minHeap.Enqueue(max, max);
        }
    }

    public double FindMedian()
    {
        if (minHeap.Count == maxHeap.Count)
            return ((double)minHeap.Peek() + maxHeap.Peek()) / 2;
        return (double)minHeap.Peek();
    }
}