using System.Runtime.InteropServices.ComTypes;

int FurthestBuilding(int[] heights, int bricks, int ladders)
{
    var minHeap = new PriorityQueue<int, int>();
    for (int i = 1; i < heights.Length; i++)
    {
        var diff = heights[i] - heights[i - 1];
        if (diff < 0) 
            continue;
        minHeap.Enqueue(diff, diff);
        if (minHeap.Count > ladders)
            bricks -= minHeap.Dequeue();
        if (bricks < 0)
            return i - 1;
    }
    return heights.Length - 1;
}