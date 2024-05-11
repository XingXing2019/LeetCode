int[] quality = { 1, 8, 3, 2 };
int[] wage = { 9, 20, 29, 44 };
var k = 2;
Console.WriteLine(MincostToHireWorkers(quality, wage, k));

double MincostToHireWorkers(int[] quality, int[] wage, int k)
{
    var heap = new PriorityQueue<int[], int>();
    var workers = new int[quality.Length][];
    for (int i = 0; i < quality.Length; i++)
        workers[i] = new[] { quality[i], wage[i] };
    workers = workers.OrderBy(x => (double)x[1] / x[0]).ToArray();
    double totalQuality = 0, res = double.MaxValue;
    foreach (var worker in workers)
    {
        totalQuality += worker[0];
        heap.Enqueue(worker, -worker[0]);
        if (heap.Count < k) continue;
        if (heap.Count > k)
            totalQuality -= heap.Dequeue()[0];
        res = Math.Min(res, totalQuality * worker[1] / worker[0]);
    }
    return Math.Min(res, totalQuality * workers[^1][1] / workers[^1][0]);
}