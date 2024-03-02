using System.Runtime.InteropServices;

int MinOperations(int[] nums, int k)
{
    var res = 0;
    var heap = new PriorityQueue<long, long>();
    foreach (var num in nums)
        heap.Enqueue(num, num);
    while (heap.Count != 0 && heap.Peek() < k)
    {
        long num1 = heap.Dequeue(), num2 = heap.Dequeue();
        var num = Math.Min(num1, num2) * 2 + Math.Max(num1, num2);
        heap.Enqueue(num, num);
        res++;
    }
    return res;
}