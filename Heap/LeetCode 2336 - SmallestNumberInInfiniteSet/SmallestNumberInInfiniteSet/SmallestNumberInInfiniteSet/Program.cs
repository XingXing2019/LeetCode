public class SmallestInfiniteSet
{
    private PriorityQueue<int, int> minHeap;
    private HashSet<int> set;
    public SmallestInfiniteSet()
    {
        minHeap = new PriorityQueue<int, int>();
        set = new HashSet<int>();
        for (int i = 1; i <= 1000; i++)
        {
            minHeap.Enqueue(i, i);
            set.Add(i);
        }
    }

    public int PopSmallest()
    {
        var res = minHeap.Dequeue();
        set.Remove(res);
        return res;
    }

    public void AddBack(int num)
    {
        if (set.Contains(num))
            return;
        minHeap.Enqueue(num, num);
        set.Add(num);
    }
}