int[] nums = { 1, 2, 3, 4 };
Console.WriteLine(MinimumDeviation(nums));

int MinimumDeviation(int[] nums)
{
    var maxHeap = new PriorityQueue<int, int>();
    int min = int.MaxValue, res = int.MaxValue;
    foreach (var num in nums)
    {
        var temp = num % 2 == 0 ? num : num * 2;
        min = Math.Min(min, temp);
        maxHeap.Enqueue(temp, -temp);
    }
    while (maxHeap.Count != 0 && maxHeap.Peek() % 2 == 0)
    {
        var max = maxHeap.Dequeue();
        max /= 2;
        min = Math.Min(min, max);
        maxHeap.Enqueue(max, -max);
        res = Math.Min(res, maxHeap.Peek() - min);
    }
    return res;
}