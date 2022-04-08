// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class KthLargest_Heap
{
    private PriorityQueue<int, int> heap;
    private int k;
    public KthLargest_Heap(int k, int[] nums)
    {
        heap = new PriorityQueue<int, int>();
        foreach (var num in nums)
            heap.Enqueue(num, num);
        while (heap.Count > k)
            heap.Dequeue();
        this.k = k;
    }

    public int Add(int val)
    {
        heap.Enqueue(val, val);
        if (heap.Count > k)
            heap.Dequeue();
        return heap.Peek();
    }
}

public class KthLargest
{
    private List<int> maxHeap;
    private int count;
    public KthLargest(int k, int[] nums)
    {
        count = k;
        maxHeap = new List<int>();
        foreach (var num in nums)
            SetMaxHeap(num);
    }

    public int Add(int val)
    {
        SetMaxHeap(val);
        return maxHeap[0];
    }

    private void SetMaxHeap(int num)
    {
        var index = maxHeap.BinarySearch(num);
        index = index < 0 ? -(index + 1) : index;
        maxHeap.Insert(index, num);
        if (maxHeap.Count > count)
            maxHeap.RemoveAt(0);
    }
}