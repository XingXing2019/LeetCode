int[] nums = { 2, 1, 3, 5, 6 };
int k = 5, multiplier = 2;
Console.WriteLine(GetFinalState(nums, k, multiplier));

int[] GetFinalState(int[] nums, int k, int multiplier)
{
    var heap = new PriorityQueue<int[], int>();
    for (int i = 0; i < nums.Length; i++)
        heap.Enqueue(new[] { nums[i], i }, nums[i] * 1000 + i);
    for (int i = 0; i < k; i++)
    {
        var min = heap.Dequeue();
        heap.Enqueue(new[] { min[0] * multiplier, min[1] }, min[0] * multiplier * 1000 + min[1]);
    }
    while (heap.Count != 0)
    {
        var min = heap.Dequeue();
        nums[min[1]] = min[0];
    }
    return nums;
}