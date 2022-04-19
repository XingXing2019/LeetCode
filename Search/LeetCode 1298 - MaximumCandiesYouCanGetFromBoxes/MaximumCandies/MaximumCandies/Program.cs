// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
{
    var heap = new PriorityQueue<int[], int>();
    var keysInHand = new HashSet<int>();
    var res = 0;
    foreach (var box in initialBoxes)
        heap.Enqueue(new []{box, status[box]}, status[box] ^ 1);
    while (heap.Count != 0)
    {
        var cur = heap.Dequeue();
        if (cur[1] == 0 && !keysInHand.Contains(cur[0])) break;
        res += candies[cur[0]];
        foreach (var key in keys[cur[0]])
            keysInHand.Add(key);
        foreach (var box in containedBoxes[cur[0]])
            heap.Enqueue(new []{box, status[box]}, status[box] ^ 1);
    }
    return res;
}