// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int MaximumProduct(int[] nums, int k)
{
    var heap = new PriorityQueue<int, int>();
    foreach (var num in nums)
        heap.Enqueue(num, num);
    for (int i = 0; i < k; i++)
    {
        var num = heap.Dequeue();
        heap.Enqueue(num + 1, num + 1);
    }
    long res = 1, mod = 1_000_000_000 + 7;
    while (heap.Count != 0)
        res = res * heap.Dequeue() % mod;
    return (int)(res % mod);
}
