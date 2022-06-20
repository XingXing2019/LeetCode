int target = 100, startFuel = 50;
int[][] stations = new[]
{
    new[] { 25, 25 },
    new[] { 50, 50 },
};

Console.WriteLine(MinRefuelStops(target, startFuel, stations));

int MinRefuelStops(int target, int startFuel, int[][] stations)
{
    var maxHeap = new PriorityQueue<int[], int>();
    int res = 0, index = 0;
    while (startFuel < target)
    {
        while (index < stations.Length && startFuel >= stations[index][0])
            maxHeap.Enqueue(stations[index], -stations[index++][1]);
        if (maxHeap.Count == 0)
            return -1;
        startFuel += maxHeap.Dequeue()[1];
        res++;
    }
    return startFuel < target ? -1 : res;
}